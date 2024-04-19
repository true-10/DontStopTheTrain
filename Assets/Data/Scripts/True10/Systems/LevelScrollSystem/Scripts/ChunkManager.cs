using System;
using System.Collections;
using System.Collections.Generic;
using True10.Managers;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

namespace True10.LevelScrollSystem
{
    public class ChunkManager : DataManager<LevelChunk>
    {
        public Action<LevelChunk> OnChunkEnter { get; set; }
        public Action<LevelChunk> OnChunkExit { get; set; }

        public override void Dispose()
        {
            Clear();
        }

        public override void Initialize()
        {

        }

        public override bool TryToAdd(LevelChunk newItem)
        {
            if (base.TryToAdd(newItem))
            {
                newItem.OnChunkEnter += OnChunkEnterHandler;
                newItem.OnChunkExit += OnChunkExitHandler;
                return true;
            }
            return false;
        }

        public override bool TryToRemove(LevelChunk itemToRemove)
        {
            if (base.TryToRemove(itemToRemove))
            {
                itemToRemove.OnChunkEnter -= OnChunkEnterHandler;
                itemToRemove.OnChunkExit -= OnChunkExitHandler;
                return true;
            }
            return false;
        }

        private void OnChunkEnterHandler(LevelChunk chunk)
        {
            OnChunkEnter?.Invoke(chunk);
        }
        private void OnChunkExitHandler(LevelChunk chunk)
        {
            OnChunkExit?.Invoke(chunk);
        }
    }
}
