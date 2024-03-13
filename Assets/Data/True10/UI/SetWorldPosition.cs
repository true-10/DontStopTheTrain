using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace True10.UI
{
    public class SetWorldPosition : MonoBehaviour
    {
        [SerializeField]
        private Vector3 _offset;
        [SerializeField]
        private Vector2 _offset2D;
        [SerializeField]
        private bool _useOffset2D = true;

        private Transform _cachedTransform;
        private Camera _camera;

        private void Start()
        {
            _cachedTransform ??= GetComponent<Transform>();
            _camera = Camera.main;
        }

        public void SetPosition(Transform lookAt)
        {
            var newPosition = _camera.WorldToScreenPoint(lookAt.position + _offset);

            if (_cachedTransform.position != newPosition)
            {
                _cachedTransform.position = newPosition;
            }
        }

        public void SetPosition2d(Transform lookAt)
        {
            var newPosition = _camera.WorldToScreenPoint(lookAt.position);// + _offset);

            if (_cachedTransform.position != newPosition)
            {
              //  _cachedTransform.position = newPosition + _offset2D;
            }
        }
    }
}


