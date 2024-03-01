using Leopotam.EcsLite;
using System;
using System.Collections.Generic;
using UnityEngine;
using static True10.LevelScrollSystem.ESC.InitChunksSystem;

namespace True10.LevelScrollSystem.ESC
{

    [Serializable]
    public enum ScrollDirection
    {
        Forward,
        Backward
    }

    [Serializable]
    public struct ScrollSettingsComponent
    {
        public int Layer;
        [Min(0)]
        public float Speed;
       // public Vector3 Direction;
        public ScrollDirection DirectionEnum;
       // public float LimitValue;
    }

    sealed class ScrollChunkSystem : IEcsRunSystem, IEcsInitSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsPool<ScrollSettingsComponent> _settings = null;
       // private readonly EcsPool<ScrollableComponent, LayerComponent>
         //   .Exclude<SnapChunkEvent, WaitingChunk> _filter = null;


        private ILevelScrollSpeedController _levelScrollSpeedController;

        public Dictionary<int, LayerData> layerDatasDictionary = new();
        private bool isLimitReached = false;

        public void Init(IEcsSystems systems)
        {
            UpdateLayers();

          //  UnityEngine.Debug.Log($"ScrollChunkSystem: Init() _filter.IsEmpty() = {_filter.IsEmpty()}");
        }

        public void Run(IEcsSystems systems)
        {
            UpdateLayers();
            foreach (var layerId in layerDatasDictionary.Keys)
            {
                ProcessLayer(layerId);
            }

        }


        private void ProcessLayer(int layer)
        {
            var layerEntities = layerDatasDictionary[layer].Entities;
            var scrollDirection = layerDatasDictionary[layer].ScrollSettingsComponent.DirectionEnum;
            foreach (var entity in layerEntities)
            {
                ProcessEntity(entity, layer);
            }
        }

        private void ProcessEntity(int i, int layer)
        {
          /*  var settings = layerDatasDictionary[layer].ScrollSettingsComponent;
            
            var direction = GetDirection(settings.DirectionEnum);
            ref var scrollable = ref _filter.Get1(i);
            ref var transform = ref scrollable.TransformToScroll;
            ref var objectToScroll = ref scrollable.ObjectToScroll;

            var pos = transform.localPosition;
            isLimitReached = IsLimitedReached(pos, layer);

            if (isLimitReached)
            {
                ref var entity = ref _filter.GetEntity(i);
                if (entity != null && entity.Has<SnapChunkEvent>() == false)
                {
                    entity.Get<SnapChunkEvent>();
                    //OnTranslate?.Invoke();
                }
            }
            else
            {
                var speed = settings.Speed * _levelScrollSpeedController.Multilplayer;
                pos += direction * speed * Time.deltaTime;
                transform.localPosition = pos;
            }*/
        }

        private void UpdateLayers()
        {
            if (layerDatasDictionary == null)
            {
                layerDatasDictionary = new();
            }
            layerDatasDictionary.Clear();

          /*  foreach (var i in _settings)
            {
                ref var settingComponent = ref _settings.Get1(i);
                var layer = settingComponent.Layer;
                var scrollDirection = settingComponent.DirectionEnum;
                List<int> layerEntities = new();// layerEntityDictionary[layer];
                ProcessEntitiesForward(entity =>
                {
                    ref var layerEntity = ref _filter.Get2(entity);
                    if (layerEntity.Layer == layer)
                    {
                        layerEntities.Add(entity);
                    }
                });
                var layerData = new LayerData()
                {
                    Entities = layerEntities,
                    ScrollSettingsComponent = settingComponent,
                    OverallLength = CalculateOverallLength(layerEntities)
                };
                layerDatasDictionary.Add(layer, layerData);
            }*/

        }

        private void ProcessEntitiesForward(Action<int> callback)
        {
         /*   for (int i = 0; i < _filter.GetEntitiesCount(); i++)
            {
                callback?.Invoke(i);
            }*/
        }

        private void ProcessEntitiesBackward(Action<int> callback)
        {
            /*for (int i = _filter.GetEntitiesCount() - 1; i >= 0; i--)
            {
                callback?.Invoke(i);
            }*/
        }

        private Vector3 GetDirection(ScrollDirection directionEnum)
        {
            switch (directionEnum)
            {
                case ScrollDirection.Forward:
                    {
                        return Vector3.forward;
                    }
                case ScrollDirection.Backward:
                    {
                        return Vector3.back;

                    }
            }
            return Vector3.zero;
        }

        private bool IsLimitedReached(Vector3 position, int layer)
        {
            var settings = layerDatasDictionary[layer].ScrollSettingsComponent;
            var overallLength = layerDatasDictionary[layer].OverallLength;
            var limit = overallLength / 2f;
            switch (settings.DirectionEnum)
            {
                case ScrollDirection.Forward:
                case ScrollDirection.Backward:
                    {
                        return Mathf.Abs(position.z) > limit;
                       // return Mathf.Abs(position.x) > limit;
                        //return Mathf.Abs(position.y) > limit;

                    }
            }
            return false;
        }

        private float CalculateOverallLength(List<int> layerEntities)
        {
            var overallLength = 0f;
            /*  for (int i = 0; i < layerEntities.Count; i++)
              {
                  var index = layerEntities[i];
                  ref var scrollable = ref _filter.Get1(index);
                  ref var objectToScroll = ref scrollable.ObjectToScroll;
                  ref var start = ref objectToScroll.startPoint;
                  ref var end = ref objectToScroll.endPoint;

                  var zLength = Mathf.Abs(end.transform.localPosition.z - start.transform.localPosition.z);
                  overallLength += zLength;
              }*/
            return overallLength;
        }
    }
}