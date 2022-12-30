using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DontStopTheTrain.Animation.DestructionSystem
{
    /// <summary>
    /// �� ���� ����� �� ������� ����������� �������������, ������� �� ���� � �����������. ��� ����� �� �������, �� ����� � �����.
    /// ������, ����������� ���� ��� ������ "���������" ��������
    /// �������� �������� � ���� � "��������� �������"
    /// ��������, �������� �����. ���� ������ ������� ���������� � ������ �������
    /// ���� �������������� � ����� (����� �������)
    /// � ������������ �������� �������� �� ����������� �� ������������ �����.
    /// � ����� �������� � "�����"
    /// </summary>
    public interface IForce
    {
        //Vector3 Direction;
        //float Duration;
    }

    public interface IDestructible
    {

    }

    //sequence of force impact
    //animationCurve, DOTWeen mmmm

    public class AnimatedDestructionSystem : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
