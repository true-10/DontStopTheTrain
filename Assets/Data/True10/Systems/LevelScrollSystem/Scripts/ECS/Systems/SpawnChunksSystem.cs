using Leopotam.EcsLite;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace True10.LevelScrollSystem.ESC
{
    public class SpawnChunksSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter/*<ScrollableComponent, LayerComponent>*/ _filter = null;
        private readonly EcsFilter/*<ScrollSettingsComponent>*/ _settings = null;
      //  private readonly EcsFilter<SetOfChunksComponent> _setsOfChunks = null;

        public void Init(IEcsSystems systems)
        {
        /*    foreach (var entity in _setsOfChunks)
            {
                var setOfChunk = _setsOfChunks.Get1(entity);

                var count = setOfChunk.Count;
                var root = setOfChunk.Root;
                for (int i = 0; i < count; i++)
                {
                    setOfChunk.Chunks.CreateRandomChunk(root);
                    ref var scrollable = ref _filter.Get1(entity);
                }

                UnityEngine.Debug.Log($"SpawnChunksSystem: Init() _filter.IsEmpty() = {_filter.IsEmpty()}");
            }*/
        }
    }
}
