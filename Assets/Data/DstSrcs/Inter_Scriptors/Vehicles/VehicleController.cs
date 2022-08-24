using System;
using System.Collections.Generic;
using UnityEngine;

namespace Interceptors.BattleSystem
{

//перки для тачек
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
        //уровень
        //опыт
        //базовые характеристики
        //список оружия
        //список перков
        //

        #endregion

        #region callbacks
        public Action OnTick { get; set; }//каждая запчасть подписывается на это

        #endregion

        #region Injectcions

        #endregion

        #region Fields
        [SerializeField] private List<PartConnector> partSpawners;
        #endregion




    }

}