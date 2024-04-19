
using System;
using UnityEngine;

namespace True10.LevelScrollSystem.ESC
{

    [Serializable]
    public struct ScrollableComponent
    {
        public ObjectToScroll ObjectToScroll;
        public Transform TransformToScroll;

    }

    [Serializable]
    public struct LayerComponent
    {
        public int Layer;
    }

    [Serializable]
    public struct ObjectToScrollComponent
    {
        public ObjectToScroll ObjectToScroll;
    }

    [Serializable]
    internal struct DirectionComponent
    {
        public Vector3 Direction; 
    }
}