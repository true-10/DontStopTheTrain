using DontStopTheTrain;
using System;
using System.Collections;
using System.Collections.Generic;
using True10.Interfaces;
using True10.LevelScrollSystem;
using True10.TriggerSystem;
using UnityEngine;
using Zenject;

namespace True10.LevelScrollSystem
{

    public class LevelChunk : MonoBehaviour, IGameLifeCycle
    {
        public Action<LevelChunk> OnChunkEnter { get; set; } 
        public Action<LevelChunk> OnChunkExit { get; set; } 
        public ObjectToScroll ObjectToScroll => _objectToScroll;
        public ChunkStaticData StaticData => _staticData;

        [Inject]
        private LevelChunksManager _chunkManager;

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
            _chunkManager.TryToAdd(this);

            _enterTrigger.OnEnter += OnChunkEnterHandler;
            _exitTrigger.OnEnter += OnChunkExitHandler;
        }

        public void Dispose()
        {
            _chunkManager.TryToRemove(this);
            _enterTrigger.OnEnter -= OnChunkEnterHandler;
            _exitTrigger.OnEnter -= OnChunkExitHandler;
        }

        private void OnChunkEnterHandler(Collider collider)
        {
            Debug.Log($"OnChunkEnterHandler {this}");
            OnChunkEnter?.Invoke(this);
        }  

        private void OnChunkExitHandler(Collider collider)
        {
            Debug.Log($"OnChunkExitHandler {this}");
            OnChunkExit?.Invoke(this);
        }

        private void OnEnable()
        {
            Initialize();
        }

        private void OnDisable()
        {
            Dispose();
        }
    }
}
