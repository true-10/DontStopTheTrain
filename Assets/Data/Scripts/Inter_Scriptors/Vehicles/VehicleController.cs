using System;
using System.Collections.Generic;
using UnityEngine;

namespace Interceptors.BattleSystem
{

//����� ��� �����
public class VehiclePerk
    {

    }

    public interface IVehicleController
    {

        #region callbacks
        Action OnTick { get; set; }

        #endregion
    }

    public class VehicleController : IVehicleController
    {
        #region fields
        //�������
        //����
        //������� ��������������
        //������ ������
        //������ ������
        //

        #endregion

        #region callbacks
        public Action OnTick { get; set; }//������ �������� ������������� �� ���

        #endregion

        #region Injectcions

        #endregion

        #region Fields
        [SerializeField] private List<PartConnector> partSpawners;
        #endregion




    }

}