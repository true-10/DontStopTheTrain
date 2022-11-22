using DontStopTheTrain.Gameplay;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace DontStopTheTrain.Train
{
    public interface ITrainController
    {

        Action OnStart { get; set; }//����� ��������
        Action OnStop { get; set; }//����� �����������
        Action<WagonData> OnSwitchWagon { get; set; }
    }


    public class TrainController : MonoBehaviour
    {
        [Inject] private ITurnController turnController;
        private List<IWagon> wagons;

        //������� ����������? ���� �������? ��������? ��������?
        //���������? ����������? ���������?

    }

}
