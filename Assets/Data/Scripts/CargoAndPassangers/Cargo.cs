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
        Humidity, //���������
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
        float State { get; }//0 - ��� �����, 1 - ��� ������
        IReadOnlyCollection<ICargoRequirements> Requirements { get; }
    }

    public class Cargo //: ICargo
    {

       // [SerializeField] private float _volume;//����� �����
        //[SerializeField] private float _weight;//��� �����
        public float State { get; private set; }//0 - ��� �����, 1 - ��� ������
    }

    public class Passenger//: ICargo
    {
        public float State { get; private set; }//0 - ��� �����, 1 - ��� ������
    }
}
