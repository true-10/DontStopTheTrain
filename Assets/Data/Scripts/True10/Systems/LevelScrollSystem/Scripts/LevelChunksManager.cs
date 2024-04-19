using DontStopTheTrain.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using True10.Extentions;
using True10.Managers;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

namespace True10.LevelScrollSystem
{
    public class LevelChunksManager : DataManager<LevelChunk>
    {
        public Action<LevelChunk> OnChunkEnter { get; set; }
        public Action<LevelChunk> OnChunkExit { get; set; }

        public LevelChunk GetRandomWeightedChunk()
        {
            var orderedChunks = GetFreeChunks()
                .OrderByDescending(chunk => chunk.StaticData.Weight)
                .ToList();

            int total = orderedChunks.Sum(ev => ev.StaticData.Weight);

            int randomPoint = UnityEngine.Random.Range(0, total);
            var overallWeight = 0;

            for (int i = 0; i < orderedChunks.Count; i++)
            {
                var chunk = orderedChunks[i];
                var weight = chunk.StaticData.Weight;
                overallWeight += weight;
                if (overallWeight >= randomPoint)
                {
                    return chunk;
                }
            }
            return GetRandomChunk();
        }

        public LevelChunk GetRandomChunk()
        {
            return GetFreeChunks().GetRandomElement();
        }

        public List<LevelChunk> GetFreeChunks()
        {
            return Items.Where(chunk => chunk.isActiveAndEnabled).ToList();
        }

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
