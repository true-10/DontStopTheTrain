using System;
using System.Net;
using UnityEngine;

namespace True10.LevelScrollSystem
{
    public class OnSnapCallback
    {
        public ScrolledObject Host;
        public ScrolledObject SnapTargetObject;
    }

    public class ObjectToScrollData
    {
        public Transform transform;
        public Vector2 size;
    }

    public class ScrolledObject : MonoBehaviour
    {
        public Action<OnSnapCallback> OnSnap { get; set; }
        public ScrolledObject SnapTargetObject { get; private set; }
        public Transform StartPoint => _startPoint;
        public Transform EndPoint => _endPoint;

        [SerializeField]
        private Transform _startPoint;
        [SerializeField]
        private Transform _endPoint;

        private Transform _cachedTransform;

        public void AlignToNext()
        {
            AlignmentWithEndPoint(SnapTargetObject.StartPoint);
            var callback = new OnSnapCallback()
            {
                Host = this,
                SnapTargetObject = SnapTargetObject
            };
            OnSnap?.Invoke(callback);
        }

        public void AlignToPrev()
        {
            AlignmentWithStartPoint(SnapTargetObject.EndPoint);
            var callback = new OnSnapCallback()
            {
                Host = this,
                SnapTargetObject = SnapTargetObject
            };
            OnSnap?.Invoke(callback);
        }
                
        public void SetPreviousObject(ScrolledObject objectToScroll)
        {
            SnapTargetObject = objectToScroll;
        }
        public void AlignmentWithEndPoint(Transform pointToAlign)
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
