using UnityEngine;

namespace True10.CameraSystem
{
    public abstract class AbstractCameraRigComponent : ScriptableObject
    {
        [SerializeField]
        private string _name;
        [SerializeField, Multiline]
        private string _comment;

        protected ICameraHolder _cameraHolder;
        protected ICameraInputReader _cameraInputReader;

        public virtual void Initialize(ICameraHolder cameraHolder, ICameraInputReader cameraInputReader)
        {
            _cameraHolder = cameraHolder;
            _cameraInputReader = cameraInputReader;
        }
        public abstract void UpdateRig();
    }
}
