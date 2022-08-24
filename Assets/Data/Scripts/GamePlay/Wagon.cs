using System.Collections;
using System.Collections.Generic;
using True10.CameraSystem;
using UnityEngine;

namespace DontStopTheTrain.Gameplay
{
    [System.Serializable]

    public class WagonData
    {
        public int Number;
        public IWagonType WagonType;
    }

    public class Wagon : MonoBehaviour, IWagon
    {
        [SerializeField] private WagonData wagonData;
        [SerializeField] private List<ICameraHolder> cameras;
        public int Number => wagonData.Number;

        public IWagonType WagonType => wagonData.WagonType;

        public int Next { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int Prev { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
