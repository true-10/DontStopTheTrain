using System;
using True10.Interfaces;
using True10.TriggerSystem;
using UnityEngine;
//using Zenject;

namespace True10.LevelScrollSystem
{
    public class LevelChunk : AbstractGameLifeCycleBehaviour
    {
        public Action<LevelChunk> OnChunkEnter { get; set; } 
        public Action<LevelChunk> OnChunkExit { get; set; } 
        public ScrolledObject ObjectToScroll => _objectToScroll;
        public ChunkStaticData StaticData => _staticData;

        [SerializeField]
        private ScrolledObject _objectToScroll;
        [SerializeField]
        protected SimpleTrigger _enterTrigger;
        [SerializeField]
        protected SimpleTrigger _exitTrigger;
        [SerializeField]
        protected ChunkStaticData _staticData;
        
        public override void Initialize()
        {
            _enterTrigger.OnEnter += OnChunkEnterHandler;
            _exitTrigger.OnEnter += OnChunkExitHandler;
        }

        public override void Dispose()
        {
            _enterTrigger.OnEnter -= OnChunkEnterHandler;
            _exitTrigger.OnEnter -= OnChunkExitHandler;
        }

        protected virtual void OnChunkEnterHandler(Collider collider)
        {
            OnChunkEnter?.Invoke(this);
        }

        protected virtual void OnChunkExitHandler(Collider collider)
        {
            OnChunkExit?.Invoke(this);
        }
    }
}