using DontStopTheTrain.Events;
using System;
using True10.Interfaces;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

namespace DontStopTheTrain.Train
{
    public class WagonSystemObject : AbstractGameLifeCycleBehaviour
    {
        public Action OnSystemInit { get; set; }
        public IWagonSystem WagonSystem { get; private set; }
        public IWagonSystemStaticData StaticData => WagonSystem.StaticData;

        public GameObject VisualGameObject => _visualGameObject;

        [Inject]
        private WagonSystemsFabric _fabric;
        [Inject]
        private WagonSystemObjectsManager _wagonSystemObjectsManager;

        [SerializeField]
        private WagonSystemStaticDataBase _wagonSystemStaticDataBase;
        [SerializeField]
        private GameObject _visualGameObject;

        /*  public void SetVisualActive(bool isActive)
          {
              _visualGameObject.SetActive(isActive);
          }*/
        public void SetNewVisualObject(GameObject newVisual)
        {
            _visualGameObject = newVisual;
        }
        public override void Initialize()
        {
            WagonSystem = _fabric.Create(_wagonSystemStaticDataBase);
            WagonSystem.Initialize();
            OnSystemInit?.Invoke();
            _wagonSystemObjectsManager.TryToAdd(this);
            //(WagonSystem as BaseWagonSystem).SetViewer(_wagonEventViewer);

        }

        public override void Dispose()
        {
            WagonSystem?.Dispose();
            _wagonSystemObjectsManager.TryToRemove(this);


            // _wagonEventViewer.OnSetEvent -= OnSetEvent;
        }

    }
}
