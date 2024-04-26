using System;
using UnityEngine;

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

    public class ObjectToScroll : ChainedObject
    {
        public Action<OnSnapCallback> OnSnap { get; set; }
        public ObjectToScroll SnapTargetObject { get; private set; }

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
                
        public void SetPreviousObject(ObjectToScroll objectToScroll)
        {
            SnapTargetObject = objectToScroll;
        }       
    }
}
