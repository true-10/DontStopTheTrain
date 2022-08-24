using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * чек поинт куска 
 * делаем +1 кусок, типа будемсчитать сколько кусков проехали
 * + начислять опыт, за пройденный кусок
 * */
public class ChunkCheckPoint : MonoBehaviour
{
    #region fields
    [SerializeField] private float _expo = 100f;
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        TrainManager tm = other.GetComponent<TrainManager>();
        if (tm == null) return;
        tm.AddExpo(_expo);
    }
}
