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
            //(WagonSystem as BaseWagonSystem).SetViewer(_wagonEventViewer);

        }

        public override void Dispose()
        {
            WagonSystem?.Dispose();


           // _wagonEventViewer.OnSetEvent -= OnSetEvent;
        }

    }
}
