using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace DontStopTheTrain
{
    public class Station
    {


    }

    public class StationView : MonoBehaviour
    {
        [Inject]
        private WagonsManager _wagonsManager;

        public void Depart()
        {
            var locomotive = _wagonsManager.GetLocomotive();
            
            //locomotive.SetSpeed(100f);
        }

        public void OpenShop()
        {

        }

        public void OpenQuestList()
        {
            //������ ������ ��� ��������� �������. ���� ������� �������� �����������, �� ����� �����. (���� ���� �����, ��������)
        }

    }
}
