using UnityEngine;

namespace True10
{
    public class SnappedObject : MonoBehaviour
    {
        public Transform StartPoint => _startPoint;
        public Transform EndPoint => _endPoint;

        [SerializeField]
        private Transform _startPoint;
        [SerializeField]
        private Transform _endPoint;

        private Transform _cachedTransform;

        public  void AlignmentWithEndPoint(Transform pointToAlign)
        {
            InitializeIfNeeded();
            if (pointToAlign == null)
            {
                Debug.Log(name + " Alignment error: pointToAlign == null");
                return;
            }
            _cachedTransform.rotation = pointToAlign.rotation;
            _cachedTransform.position = pointToAlign.position;

            _cachedTransform.position += Quaternion.AngleAxis(pointToAlign.rotation.eulerAngles.y, Vector3.up) * -EndPoint.localPosition;

        }

        public void AlignmentWithStartPoint(Transform pointToAlign)
        {
            InitializeIfNeeded();
            if (pointToAlign == null)
            {
                Debug.Log(name + " Alignment error: pointToAlign == null");
                return;
            }
            _cachedTransform.rotation = pointToAlign.rotation;
            _cachedTransform.position = pointToAlign.position;

            _cachedTransform.position += Quaternion.AngleAxis(pointToAlign.rotation.eulerAngles.y, Vector3.up) * -StartPoint.localPosition;

        }

        private void InitializeIfNeeded()
        {
            _cachedTransform ??= GetComponent<Transform>();
        }

        private void Start()
        {
            InitializeIfNeeded();
        }

        private void OnValidate()
        {
            InitializeIfNeeded();
        }
    }
}
