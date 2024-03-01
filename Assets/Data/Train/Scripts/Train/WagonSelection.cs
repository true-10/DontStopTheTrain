using System.Collections.Generic;
using True10.CameraSystem;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace DontStopTheTrain.Train
{
    public class WagonSelection : MonoBehaviour, IPointerClickHandler
    {
        [Inject]
        private ICameraController _cameraController;
        [SerializeField]
        private List<CameraHolder> _cameras;

        public void OnPointerClick(PointerEventData eventData)
        {
            //Debug.Log($"{name} OnPointerClick");
            int hash = _cameras[0].HashCode;
            var button = eventData.button;
            if (button == PointerEventData.InputButton.Left)
            {
                _cameraController.SwitchToCamera(hash);
            }
        }
    }
}
