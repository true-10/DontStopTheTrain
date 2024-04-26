using UnityEngine;

namespace True10.CameraSystem
{
    public class CameraRig : MonoBehaviour
    {
        public Transform Root => _root;
        public Transform Follow => _follow;
        public Transform LookAt => _lookAt;

        [SerializeField] private Transform _root;
        [SerializeField] private Transform _follow;
        [SerializeField] private Transform _lookAt;

        public void SetPosition(Vector3 position)
        {
            _root.position = position;
        }

        private void OnValidate()
        {
            _root ??= GetComponent<Transform>();
        }
    }
}
