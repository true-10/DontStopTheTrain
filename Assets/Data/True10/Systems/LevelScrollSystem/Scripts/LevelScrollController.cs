using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


namespace True10.LevelScrollSystem
{
    public class LevelScrollController : MonoBehaviour
    {
        #region properties
        //[SerializeField]
        private Vector3 startPosition = Vector3.zero;
        //[SerializeField]
        private Vector3 endPosition = Vector3.zero;
        [SerializeField] private Vector3 scrollDirection = default;//переделать в енум
        [SerializeField] private float chunkSize = 500f;//
        [SerializeField] private float scrollSpeed = 200f;//

        #endregion

        #region vars
        [SerializeField] private List<ObjectToScroll> objectsToScroll;
        #endregion
       
        // Start is called before the first frame update
        void Start()
        {
            Init();
        }
        

       void Init()
        {
            ObjectToScroll obj = null;
            ObjectToScroll prevObj = null;
            for (int i = 1; i < objectsToScroll.Count; i++)
            {
                obj = objectsToScroll[i];
                prevObj = objectsToScroll[i - 1];
                obj.SnapTargetObject = prevObj;
                obj.AlignToNext();
            }

            obj = objectsToScroll[0];
            prevObj = objectsToScroll[objectsToScroll.Count - 1];
            obj.SnapTargetObject = prevObj;
            obj.AlignToNext();

            var chunkNumb = objectsToScroll.Count;
            var length = chunkNumb * chunkSize;

            startPosition.z = -Mathf.Sign(scrollSpeed) * length / 2f;
            endPosition.z = Mathf.Sign(scrollSpeed) * length / 2f;
        }
       
        void LateUpdate()
        {
            ScrollAnimation();
        }

        private void ScrollAnimation()
        {
            for (int i = 0; i < objectsToScroll.Count; i++)
            {
                ObjectToScroll obj = objectsToScroll[i];
                Vector3 pos = obj.transform.localPosition;
                pos.z += scrollSpeed * Time.deltaTime;
                if (pos.z < endPosition.z)
                {
                    obj.AlignToNext();
                    return;
                    //pos.z = m_localZRange.y;
                }
                obj.transform.localPosition = pos;
            }
        }
    }
}
