using Leopotam.EcsLite;
using System.Collections.Generic;
using UnityEngine;
using static True10.LevelScrollSystem.ESC.InitChunksSystem;

namespace True10.LevelScrollSystem.ESC
{
    sealed class SnapChunkToNextSystem : IEcsRunSystem, IEcsInitSystem
    {
       // private readonly EcsWorld _world = null;
        private EcsFilter _filter;// = null;
        private EcsFilter _settings;// = null;
        private EcsPool<ScrollSettingsComponent> _settingsPool;// = null;
        private EcsPool<ScrollableComponent> snapPool; //, SnapChunkEvent, LayerComponent>
            //.Exclude<WaitingChunk> snapPool = null;
        private EcsFilter snapFilter;

        public Dictionary<int, LayerData> layerDatasDictionary = new();

        private ScrollDirection scrollDirection;

        public void Init(IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            _settings = world.Filter<ScrollSettingsComponent>().End();
            _settingsPool = world.GetPool<ScrollSettingsComponent>();

            snapFilter = world.Filter<ScrollableComponent>()
                .Inc<SnapChunkEvent>()
                .Inc<LayerComponent>()
                .Exc<WaitingChunk>()
                .End();
            snapPool = world.GetPool<ScrollableComponent>();

            foreach (var i in _settings)
            {
                ref var settingComponent = ref _settingsPool.Get(i);
                scrollDirection = settingComponent.DirectionEnum ;
            }
        }

        public void Run(IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            foreach (var i in snapFilter)
            {
                ref var scrollable = ref snapPool.Get(i);
                //ref var layerComponent = ref snapFilter.Get3(i);
                ref var objectToScroll = ref scrollable.ObjectToScroll;
                ref var nextToScroll = ref objectToScroll.SnapTargetObject;
                switch(scrollDirection)
                {
                    case ScrollDirection.Forward:
                        objectToScroll.AlignToNext();
                        break;
                    case ScrollDirection.Backward:
                        objectToScroll.AlignToPrev();
                        break;
                    default:
                        objectToScroll.AlignToNext();
                        break;
                };
                // ref var entity = ref world.GetE GetEntity(i);
              //  snapPool.Get(i).Del<SnapChunkEvent>();
            }
        }
    }

}
