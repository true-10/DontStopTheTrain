using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interceptors.BattleSystem
{
    public interface IBattleState
    {
        void OnEnter();
        void OnUpdate();
        void OnExit();
    }

    public class BattleState : IBattleState
    {
        public void OnEnter()
        {
            throw new NotImplementedException();
        }

        public void OnExit()
        {
            throw new NotImplementedException();
        }

        public void OnUpdate()
        {
            throw new NotImplementedException();
        }
    }

    public class BattleController : IBattleController
    {
        #region callbacks

        public Action OnBattleStart { get; set; }
        public Action OnBattleEnd { get; set; }
        public Action OnTurnStart { get; set; }
        public Action OnTurnEnd { get; set; }
        #endregion

        #region vars
        //сетка боя

        //список юнитов
        private List<IBattleUnit> units;
        //список перков

        //
        private List<ITeamController> teams;
        #endregion;
        public BattleController()
        {
        }

        public void SetUnits(List<IBattleUnit> units)
        {
            this.units = units;
        }

        public IEnumerator OnUpdate()
        {
            //новый раунд
            //кто ходит? нужно отсортировать тачки по скорости в список.
            //кто сходил - выходит из списка
            //оставшие тачки снова сортируются( вдруг у кого шину прокололо и он замедлился)
            //кто в очереди никого нет, то начинается новый раунд.

            //и п
           /* foreach (var team in teams)
            {
                yield return team.OnUpdate();
            }*/
            yield return null;
        }

        private void SortTeamsBySpeed()
        {
            //сортировать по скорости. у кого тачка быстрее в текущий ход - тот и ходит

        }
    }
}
