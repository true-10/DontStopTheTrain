using DontStopTheTrain.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DontStopTheTrain.Train
{
    public sealed class Wagon : MonoBehaviour
    {
        public List<WagonEventViewer> EventViewers => _eventViewers;

        [SerializeField]
        private List<WagonEventViewer> _eventViewers;
        [SerializeField] 
        private WagonData wagonData;
        [SerializeField] 
        private GameObject uiObject;


        //перенести
        private void ShowUI(bool isShow)
        {
            if (uiObject.activeInHierarchy != isShow)
            {
                uiObject.SetActive(isShow);
            }
        }
    }

    public class WagonData : IWagon
    {
        public int Number => throw new System.NotImplementedException();

        public IWagonStaticData StaticData => throw new System.NotImplementedException();

        public int Deterioration => throw new System.NotImplementedException();

        public int Next { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int Prev { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}
