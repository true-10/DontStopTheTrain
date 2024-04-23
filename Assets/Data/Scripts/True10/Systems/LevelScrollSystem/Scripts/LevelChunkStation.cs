using DontStopTheTrain.UI;
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

        [SerializeField]
        protected SimpleTrigger _stoppageTrigger;

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
        }

    }
}
