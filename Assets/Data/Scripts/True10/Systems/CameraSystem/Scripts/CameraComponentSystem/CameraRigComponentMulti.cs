using System.Collections.Generic;
using UnityEngine;

namespace True10.CameraSystem
{
    [CreateAssetMenu(fileName = "CameraRigComponentMulti", menuName = "True10/CameraSystem/RigComponents/Multi")]
    public class CameraRigComponentMulti : AbstractCameraRigComponent
    {
        [SerializeField] private List<AbstractCameraRigComponent> _components;

        public override void Init(ICameraHolder cameraHolder, ICameraInputReader cameraInputReader)
        {
            foreach (AbstractCameraRigComponent component in _components)
            {
                component.Init(cameraHolder, cameraInputReader);
            }

        }
        public override void UpdateRig()
        {
            foreach (AbstractCameraRigComponent component in _components)
            {
                component.UpdateRig();
            }
        }
    }
}
