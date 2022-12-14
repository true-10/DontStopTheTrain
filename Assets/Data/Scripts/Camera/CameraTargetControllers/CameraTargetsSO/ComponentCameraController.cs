using System.Collections;
using System.Collections.Generic;
using True10.CameraSystem;
using UnityEngine;

namespace DontStopTheTrain.Gameplay.CameraComponents
{
    public class ComponentCameraController : MonoBehaviour
    {
        [SerializeField] private CameraHolder cameraHolder;
        [SerializeField] private List<CameraControllerComponent> components;


        void Start()
        {
            foreach (CameraControllerComponent component in components)
            {
                component.Init(cameraHolder);
            }
        }

        // Update is called once per frame
        void Update()
        {
            foreach (CameraControllerComponent component in components)
            {
                component.Update();
            }
        }
    }
}
