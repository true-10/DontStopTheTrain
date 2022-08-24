using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DontStopTheTrain.Gameplay
{
    public interface ITrainController
    {

        Action OnStart { get; set; }//����� ��������
        Action OnStop { get; set; }//����� �����������
        Action OnSwitchWagon { get; set; }
    }


    public class TrainController : MonoBehaviour
    {
        private List<IWagon> wagons;

        //������� ����������? ���� �������? ��������? ��������?
        //���������? ����������? ���������?

    }

}
