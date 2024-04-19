using Leopotam.EcsLite;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace True10.LevelScrollSystem.ESC
{    
    public class InitChunksSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = null;
       // private readonly EcsFilter<ScrollableComponent, LayerComponent> _filter = null;
       // private readonly EcsFilter<ScrollSettingsComponent> _settings = null;

        public Dictionary<int, LayerData> layerDatasDictionary = new();

        public class LayerData
        {
            public List<int> Entities;
            public ScrollSettingsComponent ScrollSettingsComponent;
            public float OverallLength;
        }

        public void Init(IEcsSystems systems)
        {
            UpdateLayers();

            foreach (var layerData in layerDatasDictionary.Values)
            {
                ProcessLayer(layerData.ScrollSettingsComponent.Layer);
            }
        }

        private void ProcessLayer(int layer)
        {
            var layerEntities = layerDatasDictionary[layer].Entities;
            var scrollDirection = layerDatasDictionary[layer].ScrollSettingsComponent.DirectionEnum;
            foreach (var entity in layerEntities)
            {
                int index = layerEntities.IndexOf(entity);
                int snapEntity = GetSnapEntity(index, scrollDirection, layer);
                // ProcessEntities(snapEntity, scrollDirection, layer);
                ProcessEntity(entity, snapEntity, scrollDirection, layer, index);
            }
        }

        private void UpdateLayers()
        {
            if (layerDatasDictionary == null)
            {
                layerDatasDictionary = new();
            }
            layerDatasDictionary.Clear();

        /*    foreach (var i in _settings)
            {
                ref var settingComponent = ref _settings.Get1(i);
                var layer = settingComponent.Layer;
                var scrollDirection = settingComponent.DirectionEnum;
                List<int> layerEntities = new();// layerEntityDictionary[layer];
                ProcessEntitiesForward( entity => 
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
/*
        private void ProcessEntities(int snapEntity, ScrollDirection scrollDirection, int layer)
        {
            var entities = layerDatasDictionary[layer].Entities;
            switch (scrollDirection)
            {
                case ScrollDirection.Forward:
                    {
                        for (int i = 0; i < entities.Count; i++)
                        {
                            var entity = entities[i];
                            ProcessEntity(entity, snapEntity, scrollDirection, layer, i);
                        }
                    }
                    break;
                case ScrollDirection.Backward:
                    {
                        for (int i = entities.Count - 1; i >= 0; i++)
                        {
                            var entity = entities[i];
                            ProcessEntity(entity, snapEntity, scrollDirection, layer, i);
                        }
                    }
                    break;
            }
        }
*/
        private float CalculateOverallLength(List<int> layerEntities)
        {
            var overallLength = 0f;
           /* for (int i = 0; i < layerEntities.Count; i++)
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

        private void ProcessEntitiesForward(Action<int> callback)
        {
            /*for (int i = 0; i < _filter.GetEntitiesCount(); i++)
            {
                callback?.Invoke(i);
            }*/
        }

        private void ProcessEntitiesBackward(Action<int> callback)
        {
            /*for (int i = _filter.GetEntitiesCount()-1; i >=0 ; i--)
            {
                callback?.Invoke(i);
            }*/
        }

        private void ProcessEntity(int entity, int snapEntity, ScrollDirection scrollDirection, int layer, int index)
        {
        /*    ref var scrollable = ref _filter.Get1(entity);
            ref var nextScrollable = ref _filter.Get1(snapEntity);
            ref var objectToScroll = ref scrollable.ObjectToScroll;
            ref var transform = ref scrollable.TransformToScroll;
            ref var start = ref objectToScroll.startPoint;
            ref var end = ref objectToScroll.endPoint;

            objectToScroll.SetPreviousObject(nextScrollable.ObjectToScroll);

            var zLength = Mathf.Abs(end.transform.localPosition.z - start.transform.localPosition.z);

            var newPos = Vector3.zero;
            var overallLength = layerDatasDictionary[layer].OverallLength;
            newPos.z = -overallLength / 2f + index * zLength;
            objectToScroll.gameObject.name = $"objectToScroll_L{layer}_{index}";
            transform.SetSiblingIndex(index);
            transform.position = newPos;

            snapEntity = GetSnapEntity(entity, scrollDirection, layer);*/
        }

        private int GetSnapEntity(int current,  ScrollDirection scrollDirection, int layer)
        {
            switch (scrollDirection)
            {
                case ScrollDirection.Forward: return GetNextEnity(layer, current);
                case ScrollDirection.Backward: return GetPrevEnity(layer, current);
            }
            return 0;
        }

        private int GetNextEnity(int layer, int current)
        {
            var entities = layerDatasDictionary[layer].Entities;
            int next = current + 1;
           // if (next > _filter.GetEntitiesCount() - 1)
            if (next > entities.Count - 1)
            {
                next = 0;
            }
            return entities[next];
        }

        private int GetPrevEnity(int layer, int current)
        {
            var entities = layerDatasDictionary[layer].Entities;
            int prev = current - 1;
            if (prev < 0)
            {
                prev = layerDatasDictionary[layer].Entities.Count - 1;
            }
           // Debug.Log($"GetPrevEnity() layer = {layer} current = {current} entities.Count = {entities.Count}");
            return entities[prev];
        }

    }
}
