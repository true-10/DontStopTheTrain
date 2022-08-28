using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DontStopTheTrain.Gameplay
{



    public interface IWagonManager
    {
        List<IWagon> Wagons { get; set; }
        IWagon GetWagonByNumber(int number);
    }

    
    public interface IWagonType //или енум?
    {

    }

    public interface IWagon
    {
        int Number { get; } //номер вагона
        IWagonType WagonType { get; } //тип вагона

        int Next { get; set; } //номер следующего
        int Prev { get; set; } //номер пред

        //CameraPreset CameraPreset { get; set; }
    }

    public interface IWagonController
    {

    }

    public class WagonController : MonoBehaviour
    {
        [SerializeField] private Wagon locomotive;
        [SerializeField] private List<Wagon> wagons;


    }
}
