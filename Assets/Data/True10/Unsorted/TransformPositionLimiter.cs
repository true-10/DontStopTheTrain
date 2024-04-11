using True10.Extentions;
using UnityEngine;

namespace True10
{
    public class TransformPositionLimiter : MonoBehaviour
    {
        [SerializeField]
        private Transform _centerTransform;
        [SerializeField]
        private Bounds _limits;
        [SerializeField]
        private bool _xLimit = true;
        [SerializeField]
        private bool _yLimit = true;
        [SerializeField]
        private bool _zLimit = true;

        private Transform _cachedTransform;

        public void SetExtents(float? x = null, float? y = null, float? z = null)
        {
            if (x != null)
            {
                _limits.extents = _limits.extents.With(x: x.Value);
            }
            if (y != null)
            {
                _limits.extents = _limits.extents.With(y: y.Value);
            }
            if (z != null)
            {
                _limits.extents = _limits.extents.With(z: z.Value);
            }
        }

        public void TryToLimit()
        {
            var center = Vector3.zero;
            if (_centerTransform != null)
            {
                center = _centerTransform.position;
            }
            var pos = _cachedTransform.position;

            var max = 0f;
            var min = 0f;
            if (_xLimit)
            {
                max = center.x + _limits.center.x + _limits.extents.x;
                min = center.x + _limits.center.x - _limits.extents.x;
                pos.x = Mathf.Clamp(pos.x, min, max);
            }
            if (_yLimit)
            {
                max = center.y + _limits.center.y + _limits.extents.y;
                min = center.y + _limits.center.y - _limits.extents.y;
                pos.y = Mathf.Clamp(pos.y, min, max);
            }
            if (_zLimit)
            {
                max = center.z + _limits.center.z + _limits.extents.z;
                min = center.z + _limits.center.z - _limits.extents.z;
                pos.z = Mathf.Clamp(pos.z, min, max);
            }
            _cachedTransform.position = pos;
        }

        private void Start()
        {
            _cachedTransform ??= GetComponent<Transform>();
        }

        private void LateUpdate()
        {
            TryToLimit();
        }

    }
}

