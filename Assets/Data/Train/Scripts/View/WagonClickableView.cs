using DontStopTheTrain.Events;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace DontStopTheTrain.Train
{
    public sealed class WagonClickableView : BaseClickableView
    {
        [Inject]
        private EventController _eventController;

        [SerializeField]
        private List<WagonEventViewer> _eventViewers;
        [SerializeField]
        private List<WagonEventController> _systemViewers;
        [SerializeField] 
        private BoxCollider _boxCollider;
        [SerializeField] 
        private WagonAlarm _alarm;

        public override void Initialize()
        {
            base.Initialize();
            _boxCollider ??= GetComponent<BoxCollider>();

            _eventController.OnFocus += OnEventFocus;
            _eventViewers.ForEach(viewer => viewer.OnSetEvent += OnSetEvent);
        }

        public override void Dispose()
        {
            base.Dispose();

            _eventController.OnFocus -= OnEventFocus;
            _eventViewers.ForEach(viewer => viewer.OnSetEvent -= OnSetEvent);
        }

        protected override void OnClickViewHandler()
        {
            _boxCollider.enabled = false;
          //  _systemViewers.ForEach(viewer => viewer.IsClickable = true);
        }

        private void OnEventFocus(IEvent eventData)
        {
            if (_eventViewers.Any(viewer => viewer.ActiveEvent == eventData))
            {
                OnClickViewHandler();
            }
        }

        protected override void OnExitViewHandler()
        {
            _boxCollider.enabled = true;
          //  _systemViewers.ForEach(viewer => viewer.IsClickable = false);
        }


        private void OnSetEvent(IEvent eventData)
        {
            if (eventData == null)
            {
                if (_eventViewers.All(viewer => viewer.IsFree))
                {
                    _alarm.AlarmOff();
                }
                return;
            }
            _alarm.AlarmOn();
        }

        protected override void OnValidate()
        {
            base.OnValidate();
            _boxCollider ??= GetComponent<BoxCollider>();
            //_wagonUIOnClick ??= GetComponent<WagonUIOnClick>();
        }
    }
   
}