using System.Collections;
using System.Collections.Generic;
using True10.StaticData;
using UnityEngine;

namespace DontStopTheTrain
{
    public enum CargoRequirementTypes
    {
        None,
        Temperature,
        Humidity, //влажность
        Water,
        Food,
        Comfort
    }
    public enum CargoType
    {
        Passengers,

    }

    public interface ICargoRequirements
    {
        CargoRequirementTypes Type { get; }
        float Value { get; }
    }

    public interface ICargoStaticData    
    {
        CargoType Type { get; }
        Information Info { get; }
    }

    public interface ICargo
    {
        ICargoStaticData StaticData { get; }
        float State { get; }//0 - все плохо, 1 - все хорошо
        IReadOnlyCollection<ICargoRequirements> Requirements { get; }
    }

    public class Cargo //: ICargo
    {

       // [SerializeField] private float _volume;//объем груза
        //[SerializeField] private float _weight;//вес груза
        public float State { get; private set; }//0 - все плохо, 1 - все хорошо
    }

    public class Passenger//: ICargo
    {
        public float State { get; private set; }//0 - все плохо, 1 - все хорошо
    }
}
