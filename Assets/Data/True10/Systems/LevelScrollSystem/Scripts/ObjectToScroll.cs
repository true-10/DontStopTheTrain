using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace True10.LevelScrollSystem
{
    public class OnSnapCallback
    {
        public ObjectToScroll Host;
        public ObjectToScroll SnapTargetObject;
    }

    public class ObjectToScrollData
    {
        public Transform transform;
        public Vector2 size;
    }

    public class ObjectToScroll : MonoBehaviour
    {
        public Action<OnSnapCallback> OnSnap { get; set; }

        public Transform StartPoint => _startPoint;
        public Transform EndPoint => _endPoint;
        public ObjectToScroll SnapTargetObject { get; private set; }

        [Inject]
        private ChunkManager _chunkManager;

        [SerializeField]
        private Transform _startPoint;
        [SerializeField]
        private Transform _endPoint;

        public void AlignToNext()
        {
            AlignmentWithEndPoint(SnapTargetObject.StartPoint);
        }

        public void AlignToPrev()
        {
            AlignmentWithStartPoint(SnapTargetObject.EndPoint);
        }

        public void IncreaseY()
        {
            var pos = transform.localPosition ;

            pos.y += 200f;
            transform.localPosition = pos;
            
        }

        public void SetPreviousObject(ObjectToScroll objectToScroll)
        {
            SnapTargetObject = objectToScroll;
           //Debug.Log($"{name}: SetPreviousObject ( {objectToScroll.name} )");
        }

        private void AlignmentWithEndPoint(Transform pointToAlign)
        {
            if (pointToAlign == null)
            {
                Debug.Log(name + " Alignment error: pointToAlign == null");
                return;
            }
            transform.rotation = pointToAlign.rotation;
            transform.position = pointToAlign.position;

            //transform.position += Quaternion.AngleAxis(pointToAlign.rotation.eulerAngles.y, Vector3.up) * -startPoint.localPosition;
            transform.position += Quaternion.AngleAxis(pointToAlign.rotation.eulerAngles.y, Vector3.up) * -EndPoint.localPosition;

            var callback = new OnSnapCallback()
            {
                Host = this,
                SnapTargetObject = SnapTargetObject
            };
            OnSnap?.Invoke(callback);
        }

        private void AlignmentWithStartPoint(Transform pointToAlign)
        {
            if (pointToAlign == null)
            {
                Debug.Log(name + " Alignment error: pointToAlign == null");
                return;
            }
            transform.rotation = pointToAlign.rotation;
            transform.position = pointToAlign.position;

            transform.position += Quaternion.AngleAxis(pointToAlign.rotation.eulerAngles.y, Vector3.up) * -StartPoint.localPosition;

            var callback = new OnSnapCallback()
            {
                Host = this,
                SnapTargetObject = SnapTargetObject
            };
            OnSnap?.Invoke(callback);
        }


        private void OnEnable()
        {
            _chunkManager.TryToAdd(this);
        }

        private void OnDisable()
        {
            _chunkManager.TryToRemove(this);
        }
    }
}
