using UnityEngine;

namespace True10.AnimationSystem
{
    public class ObjectRotation : MonoBehaviour
    {
        [SerializeField]
        private bool _isLocal = true;
        [SerializeField]
        private float _xRotationSpeed = 0;
        [SerializeField]
        private float _yRotationSpeed = 0;
        [SerializeField]
        private float _zRotationSpeed = 0;

        private Transform _cachedTranform;

        public void SetSpeedRotation(float? x = null, float? y = null, float? z = null)
        {
            if (x != null)
            {
                _xRotationSpeed = x.Value;
            }
            if (y != null)
            {
                _yRotationSpeed = y.Value;
            }
            if (z != null)
            {
                _zRotationSpeed = z.Value;
            }
        }

        private void RotationUpdate()
        {
            Space rotationSpace = _isLocal ? Space.Self : Space.World;
            transform.Rotate(Time.fixedDeltaTime * new Vector3(_xRotationSpeed, _yRotationSpeed, _zRotationSpeed), rotationSpace);
        }

        private void OnValidate()
        {
            _cachedTranform ??= GetComponent<Transform>();
        }

        private void Start()
        {
            _cachedTranform ??= GetComponent<Transform>();
        }

        private void FixedUpdate()
        {
            RotationUpdate();
        }
    }
}
