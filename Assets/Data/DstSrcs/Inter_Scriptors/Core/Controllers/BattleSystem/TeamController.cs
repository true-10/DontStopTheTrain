using Interceptors.BattleSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interceptors.BattleSystem
{
    public interface ITurnCallback
    {
        TeamType Team { get; set; }//кто сходил
                                   //кем сходил
                                   //какой номер хода?
                                   //
    }
    public class TurnCallback : ITurnCallback
    {
        public TeamType Team { get; set; }
    }

    public interface ITeamController
    {
        int Id { get; set; }
        TeamType Team { get; set; }
        Action<ITurnCallback> OnTurnStart { get; set; }
        Action<ITurnCallback> OnTurnEnd { get; set; }
        IEnumerator OnUpdate();
        List<IBattleUnit> GetUnits();

        /* void OnUpdate();//IEnumerator OnUpdate();
         bool IsRoundComplete();//завершен ли ход?
         void StartRound(BattleVehicle vehicle);//
                                                // void RunAway();//сбежать
                                                //void Wait();//пропустить очередь
         List<BattleVehicle> GetVehicleList();*/
    }

    public class TeamController : MonoBehaviour, ITeamController
    {
        #region callbacks
        public Action<ITurnCallback> OnTurnStart { get; set; }
        public Action<ITurnCallback> OnTurnEnd { get; set; }
        #endregion

        #region fields
        public int Id { get; set; }
        public TeamType Team { get; set; }

        #endregion

        #region vars
        //список юнитов
        private List<BattleUnit> units;
        private BattleUnit currentUnit;
        #endregion

        public TeamController(List<BattleUnit> units)
        {
            this.units = units;
        }

        public List<IBattleUnit> GetUnits()
        {
            List<IBattleUnit> result = new List<IBattleUnit>();
            foreach (var unit in units)
            {
                result.Add(unit);
            }
            return result;
        }
        
        public IEnumerator OnUpdate()
        {
            var turnCalback = new TurnCallback();

            OnTurnEnd?.Invoke(turnCalback);
            yield return null;
        }
    }

    public enum TeamType
    {
        Ally,
        Enemy
    }
}
