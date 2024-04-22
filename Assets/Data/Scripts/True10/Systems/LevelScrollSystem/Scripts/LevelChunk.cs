using System;
using True10.Interfaces;
using True10.TriggerSystem;
using UnityEngine;
//using Zenject;

namespace True10.LevelScrollSystem
{

    public class LevelChunk : MonoBehaviour, IGameLifeCycle
    {
        public Action<LevelChunk> OnChunkEnter { get; set; } 
        public Action<LevelChunk> OnChunkExit { get; set; } 
        public ObjectToScroll ObjectToScroll => _objectToScroll;
        public ChunkStaticData StaticData => _staticData;

       // [Inject]
        //private LevelChunksManager _chunkManager;

        [SerializeField]
        private ObjectToScroll _objectToScroll;
        [SerializeField]
        private SimpleTrigger _enterTrigger;
        [SerializeField]
        private SimpleTrigger _exitTrigger;
        [SerializeField]
        private ChunkStaticData _staticData;
        
        public void Initialize()
        {
        //    _chunkManager.TryToAdd(this);

            _enterTrigger.OnEnter += OnChunkEnterHandler;
            _exitTrigger.OnEnter += OnChunkExitHandler;
        }

        public void Dispose()
        {
         //   _chunkManager.TryToRemove(this);
            _enterTrigger.OnEnter -= OnChunkEnterHandler;
            _exitTrigger.OnEnter -= OnChunkExitHandler;
        }

        protected virtual void OnChunkEnterHandler(Collider collider)
        {
          //  Debug.Log($"OnChunkEnterHandler {this}");
            OnChunkEnter?.Invoke(this);
        }

        protected virtual void OnChunkExitHandler(Collider collider)
        {
            //Debug.Log($"OnChunkExitHandler {this}");
            OnChunkExit?.Invoke(this);
        }

        private void Start()
        {
            Initialize();
        }


        private void OnDestroy()
        {
            Dispose();
        }
    }

    public class LevelChunkStation : LevelChunk
    {

        protected override void OnChunkEnterHandler(Collider collider)
        {
            OnChunkEnter?.Invoke(this);
        }

        protected override void OnChunkExitHandler(Collider collider)
        {
            OnChunkExit?.Invoke(this);
        }
    }
}
