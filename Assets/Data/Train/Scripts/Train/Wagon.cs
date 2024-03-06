using DontStopTheTrain.Events;
using DontStopTheTrain.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace DontStopTheTrain.Train
{
    public sealed class Wagon : MonoBehaviour
    {
        public List<WagonEventViewer> EventViewers => _eventViewers;

        [Inject]
        private UIController _uiController;

        [SerializeField]
        private List<WagonEventViewer> _eventViewers;
        [SerializeField] 
        private WagonData _wagonData;
        [SerializeField] 
        private ClickOnObject _clicker;
        
        private void OnWagonClick()
        {

        }

        private void OnEnable()
        {
            _clicker.OnClick += OnWagonClick;
        }

        private void OnDisable()
        {
            _clicker.OnClick -= OnWagonClick;
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
