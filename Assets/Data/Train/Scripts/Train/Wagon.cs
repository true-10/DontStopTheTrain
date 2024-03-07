using DontStopTheTrain.Events;
using DontStopTheTrain.UI;
using System.Collections;
using System.Collections.Generic;
using True10.CameraSystem;
using UnityEngine;
using Zenject;

namespace DontStopTheTrain.Train
{
    public sealed class Wagon : MonoBehaviour
    {
        public List<WagonEventViewer> EventViewers => _eventViewers;
        public IWagon WagonData => _wagonData;

        [Inject]
        private UIController _uiController;

        [SerializeField]
        private List<WagonEventViewer> _eventViewers;
        [SerializeField] 
        private WagonData _wagonData;
        [SerializeField] 
        private CameraHolder _cameraHolder;
        [SerializeField] 
        private ClickOnObject _clicker;
        [SerializeField] 
        private BoxCollider _boxCollider;
        
        public void Exit()
        {
            _cameraHolder.TurnOff();
            _boxCollider.enabled = true;
            _uiController.MainGamePlay.Show();
            _eventViewers.ForEach(viewer => viewer.IsClickable = false);
        }

        private void OnWagonClick()
        {
            _cameraHolder.TurnOn();
            _boxCollider.enabled = false;
            _uiController.Wagon.Show(this);
            _uiController.MainGamePlay.Hide();
            _eventViewers.ForEach(viewer => viewer.IsClickable = true);
        }

        private void OnEnable()
        {
            _clicker.OnClick += OnWagonClick;
        }

        private void OnDisable()
        {
            _clicker.OnClick -= OnWagonClick;
        }

        private void OnValidate()
        {
            _boxCollider ??= GetComponent<BoxCollider>();
        }

        private void Start()
        {
            _boxCollider ??= GetComponent<BoxCollider>();
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
