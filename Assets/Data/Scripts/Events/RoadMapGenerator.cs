using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DontStopTheTrain.Events //� ����� ������ ������?
{
    /// <summary>
    /// ���������� ���� �� ������� �� �������
    /// ���������� ���
    /// ������� �� �����������?
    /// ������� �� ��� (����� ������� � ������)
    /// ������� �� ����� ���� (�����/�������, ����� �������, ���� ������ � ������)
    /// ������� �� ��������
    /// ������� �� �������
    /// </summary>
    public class RoadMapGenerator : MonoBehaviour
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

    public class RoadMapData
    {
        public List<RoadMapEvent> events;
    }

    public class RoadMapEvent
    {
        public int id;

    }
}
