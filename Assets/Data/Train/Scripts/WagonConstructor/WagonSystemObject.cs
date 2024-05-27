using DontStopTheTrain.Events;
using True10.Interfaces;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

namespace DontStopTheTrain.Train
{



    public class WagonSystemObject : AbstractGameLifeCycleBehaviour
    {
        public IWagonSystem WagonSystem { get; private set; }
        public IWagonSystemStaticData StaticData => WagonSystem.StaticData;


        [Inject]
        private WagonSystemsFabric _fabric;
        [Inject]
        private WagonSystemObjectsManager _wagonSystemObjectsManager;

        [SerializeField]
        private WagonSystemStaticDataBase _wagonSystemStaticDataBase;
        [SerializeField]
        private GameObject _visualGameObject;

        public void SetVisualActive(bool isActive)
        {
            _visualGameObject.SetActive(isActive);
        }

        public override void Initialize()
        {
            WagonSystem = _fabric.Create(_wagonSystemStaticDataBase);
            WagonSystem.Initialize();
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
