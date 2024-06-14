using DontStopTheTrain.Events;
using DontStopTheTrain.Train;
using True10.Interfaces;
using UnityEngine;
using Zenject;

namespace DontStopTheTrain
{
    public sealed class WagonEventController : AbstractGameLifeCycleBehaviour
    {
        public IEvent ActiveEvent { get; private set; }

        [SerializeField]
        private WagonEventViewer _wagonEventViewer;
        [SerializeField]
        private WagonSystemObject _wagonSystemObject;
      
        [SerializeField]
        private WagonSystemUIOnClick _wagonSystemUIOnClick;

        public override void Initialize()
        {
            _wagonSystemObject.OnSystemInit += OnSystemInit;
            _wagonEventViewer.OnSetEvent += OnSetEvent;

        }

        public override void Dispose()
        {
            _wagonSystemObject.OnSystemInit -= OnSystemInit;
            _wagonEventViewer.OnSetEvent -= OnSetEvent;
        }

        private void OnSystemInit()
        {
            (_wagonSystemObject.WagonSystem as BaseWagonSystem).SetViewer(_wagonEventViewer);
        }

        private void OnSetEvent(IEvent eventData)
        {
            ActiveEvent = eventData;
            _wagonSystemUIOnClick.SetEvent(eventData);

        }

    }
}
