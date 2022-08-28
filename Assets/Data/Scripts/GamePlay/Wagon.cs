using System.Collections;
using System.Collections.Generic;
using True10.CameraSystem;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace DontStopTheTrain.Gameplay
{
    [System.Serializable]

    public class WagonData
    {
        public int Number;
        public IWagonType WagonType;
    }

    public class Wagon : MonoBehaviour, IWagon, IPointerClickHandler
    {
        [Inject] private ICameraController cameraController;
        [SerializeField] private WagonData wagonData;
        [SerializeField] private List<CameraHolder> cameras;
        public int Number => wagonData.Number;

        public IWagonType WagonType => wagonData.WagonType;

        public int Next { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int Prev { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log($"{name} OnPointerClick");
            int hash = cameras[0].HashCode;
            cameraController.SwitchToCamera(hash);
        }
    }
}
