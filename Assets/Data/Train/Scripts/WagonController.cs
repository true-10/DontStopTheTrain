using System;
using System.Collections.Generic;
using UnityEngine;

namespace DontStopTheTrain.Train
{

    public interface IWagonManager
    {
        List<IWagon> Wagons { get; set; }
        IWagon GetWagonByNumber(int number);
    }


    public interface IWagonController
    {

    }

    public class WagonController : MonoBehaviour
    {
        [SerializeField] private WagonView locomotive;
        [SerializeField] private List<WagonView> wagons;

        //public Action<WagonData> OnWagonClick { get; set; }


    }
}
