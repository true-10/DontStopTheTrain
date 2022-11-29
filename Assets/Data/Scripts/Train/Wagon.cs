using DontStopTheTrain.Events;
using System.Collections;
using System.Collections.Generic;
using True10.CameraSystem;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace DontStopTheTrain.Train
{


    [System.Serializable]
    public class WagonData
    {
        public int Number;
        public IWagonType WagonType;
        public List<int> wagonEvents;
    }

    public class Wagon : MonoBehaviour, IWagon, IPointerClickHandler
    {
        [Inject] 
        private ICameraController cameraController;
        [SerializeField] 
        private WagonDataScriptableObject wagonDataScriptableObject;
        [SerializeField] 
        private WagonData wagonData;
        [SerializeField] 
        private List<CameraHolder> cameras;
        //[SerializeField] private List<AbstractMonoEvent> events;
        public int Number => wagonData.Number;

        public IWagonType WagonType => wagonData.WagonType;

        public int Next { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int Prev { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public void OnPointerClick(PointerEventData eventData)
        {
            //Debug.Log($"{name} OnPointerClick");
            int hash = cameras[0].HashCode;
            var button = eventData.button;
            if (button == PointerEventData.InputButton.Left)
            {
                cameraController.SwitchToCamera(hash);
            }
        }


        public void Update()
        {
            
        }
    }
}
