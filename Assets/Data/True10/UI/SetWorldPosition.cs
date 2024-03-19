using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace True10.UI
{
    public class SetWorldPosition : MonoBehaviour
    {
        [SerializeField]
        private Vector3 _offset;

        private Transform _cachedTransform;
        private Camera _camera;

        private void OnValidate()
        {
            _cachedTransform ??= GetComponent<Transform>();
            _camera = Camera.main;
        }

        private void OnEnable()
        {
            _cachedTransform ??= GetComponent<Transform>();
            _camera = Camera.main;
        }

        public void SetPosition(Transform lookAt)
        {
            if (lookAt == null)
            {
                return;
            }
            var newPosition = _camera.WorldToScreenPoint(lookAt.position + _offset);

            if (_cachedTransform.position != newPosition)
            {
                _cachedTransform.position = newPosition;
            }
        }
    }
}


