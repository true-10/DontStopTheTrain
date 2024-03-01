using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace True10.LevelScrollSystem
{
    public class OnSnapCallBack
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
        public Action<OnSnapCallBack> OnSnap { get; set; }
        #region fields
        public Transform startPoint;
        public Transform endPoint;
        public ObjectToScroll SnapTargetObject;
        #endregion


        void AlignmentWithEndPoint(Transform pointToAlign)
        {
            if (pointToAlign == null)
            {
                Debug.Log(name + " Alignment error: pointToAlign == null");
                return;
            }
            transform.rotation = pointToAlign.rotation;
            transform.position = pointToAlign.position;

            //transform.position += Quaternion.AngleAxis(pointToAlign.rotation.eulerAngles.y, Vector3.up) * -startPoint.localPosition;
            transform.position += Quaternion.AngleAxis(pointToAlign.rotation.eulerAngles.y, Vector3.up) * -endPoint.localPosition;
            
            var callback = new OnSnapCallBack()
            {
                Host = this,
                SnapTargetObject = SnapTargetObject
            };
            OnSnap?.Invoke(callback);
        }

        void AlignmentWithStartPoint(Transform pointToAlign)
        {
            if (pointToAlign == null)
            {
                Debug.Log(name + " Alignment error: pointToAlign == null");
                return;
            }
            transform.rotation = pointToAlign.rotation;
            transform.position = pointToAlign.position;

            transform.position += Quaternion.AngleAxis(pointToAlign.rotation.eulerAngles.y, Vector3.up) * -startPoint.localPosition;
            
            var callback = new OnSnapCallBack()
            {
                Host = this,
                SnapTargetObject = SnapTargetObject
            };
            OnSnap?.Invoke(callback);
        }

        public void AlignToNext()
        {
            AlignmentWithEndPoint(SnapTargetObject.startPoint);
        }

        public void AlignToPrev()
        {
            AlignmentWithStartPoint(SnapTargetObject.endPoint);
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

    }
}
