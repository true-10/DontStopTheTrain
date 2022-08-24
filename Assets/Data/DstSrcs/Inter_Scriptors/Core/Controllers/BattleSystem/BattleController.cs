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
        //����� ���

        //������ ������
        private List<IBattleUnit> units;
        //������ ������

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
            //����� �����
            //��� �����? ����� ������������� ����� �� �������� � ������.
            //��� ������ - ������� �� ������
            //�������� ����� ����� �����������( ����� � ���� ���� ��������� � �� ����������)
            //��� � ������� ������ ���, �� ���������� ����� �����.

            //� �
           /* foreach (var team in teams)
            {
                yield return team.OnUpdate();
            }*/
            yield return null;
        }

        private void SortTeamsBySpeed()
        {
            //����������� �� ��������. � ���� ����� ������� � ������� ��� - ��� � �����

        }
    }
}
