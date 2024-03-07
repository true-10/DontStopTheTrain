using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Wagon_obsolete : TrainPart //сам вагон изнашивается
{
    #region fields
    [SerializeField] private Transform _startJoint;
    [SerializeField] private Transform _endJoint;
    public Wagon_obsolete _prev;
    //вес вагона
    //вес груза
    #endregion

    void Alignment(Transform pointToAlign)
    {
        if (pointToAlign == null)
        {
            Debug.Log(name + " Alignment error: pointToAlign == null");
            return;
        }
        //m_alignPoint = pointToAlign;
        transform.rotation = pointToAlign.rotation;
        transform.position = pointToAlign.position;

        transform.position += Quaternion.AngleAxis(pointToAlign.rotation.eulerAngles.y, Vector3.up) * -_startJoint.localPosition;
    }
    public void AlignToPrev()
    {
        Alignment(_prev._endJoint);
    }
}


//данные вагона
/*public class WagonData
{
    //списко апгрейдов
}*/