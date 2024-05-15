using DontStopTheTrain.UI;
using True10.CameraSystem;
using True10.TriggerSystem;
using UnityEngine;
using Zenject;
//using Zenject;

namespace True10.LevelScrollSystem
{
    public class LevelChunkStation : LevelChunk
    {
        [Inject]
        private UIContainer _UIContainer;
        [Inject]
        private DayTimeSystem.DayTimeSystem _dayTimeSystem;

        [SerializeField]
        protected SimpleTrigger _stoppageTrigger;
        
        [SerializeField]
        protected CameraHolder _cameraHolder;

        public override void Initialize()
        {
            base.Initialize();
            _stoppageTrigger.OnEnter += OnStoppageTriggerEnterHandler;
        }

        public override void Dispose()
        {
            base.Dispose();
            _stoppageTrigger.OnEnter -= OnStoppageTriggerEnterHandler;
        }

        protected void OnStoppageTriggerEnterHandler(Collider collider)
        {
            _UIContainer.MainGamePlay.Hide();
            _UIContainer.Station.Show();
            _dayTimeSystem.Pause();
            
            _cameraHolder?.SwitchToThisCamera();
        }

    }
}
