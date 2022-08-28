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

    
    public interface IWagonType //��� ����?
    {

    }

    public interface IWagon
    {
        int Number { get; } //����� ������
        IWagonType WagonType { get; } //��� ������

        int Next { get; set; } //����� ����������
        int Prev { get; set; } //����� ����

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
