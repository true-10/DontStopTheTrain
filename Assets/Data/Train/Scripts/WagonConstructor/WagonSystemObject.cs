using DontStopTheTrain.Events;
using True10.Interfaces;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

namespace DontStopTheTrain.Train
{
    public enum ViewMode
    {
        Game = 0,
        Editor = 1
    }



    public class WagonSystemObject : AbstractGameLifeCycleBehaviour
    {
        public IWagonSystem WagonSystem { get; private set; }


        [Inject]
        private WagonSystemsFabric _fabric;

        [SerializeField]
        private WagonSystemStaticDataBase _wagonSystemStaticDataBase;

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
