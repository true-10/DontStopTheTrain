using System.Collections;
using System.Collections.Generic;
using True10.CameraSystem;
using UnityEngine;
using Zenject;

namespace DontStopTheTrain.Gameplay.CameraComponents
{

    [CreateAssetMenu(fileName = "MultiControllerCompoment", menuName = "DST/CameraControllerComponentSO/Multi")]
    public class MultiControllerCompoment : CameraControllerComponent
    {
        [SerializeField] private List<CameraControllerComponent> components;
           
        public override void Init(CameraHolder cameraHolder)
        {
            this.cameraHolder = cameraHolder;
            foreach (CameraControllerComponent component in components)
            {
                component.Init(cameraHolder);
            }

        }
        public override void Update()
        {
            foreach (CameraControllerComponent component in components)
            {
                component.Update();
            }
        }
    }
}
