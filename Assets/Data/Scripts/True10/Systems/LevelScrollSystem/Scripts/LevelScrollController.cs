using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Zenject;
using System.Linq;

namespace True10.LevelScrollSystem
{
    public class LevelScroller : MonoBehaviour//,IGameLifeCycle
    {
        [Inject]
        private ChunkManager _chunkManager;
        [SerializeField]
        private float _scrollSpeed = 200f;//

    }

    public class LevelScrollController : MonoBehaviour//,IGameLifeCycle
    {
        [Inject]
        private ChunkManager _chunkManager;

        [SerializeField] 
        private Vector3 _scrollDirection = default;//переделать в енум
        [SerializeField] 
        private float _chunkSize = 500f;//
        [SerializeField] 
        private float _scrollSpeed = 200f;//
        [SerializeField]
        private Transform _startPoint;
        [SerializeField]
        private Transform _endPoint;


        private Vector3 _startPosition = Vector3.zero;        
        private Vector3 _endPosition = Vector3.zero;

        public void SetSpeed(float speed)
        {
            _scrollSpeed = -speed;
        }

        private void Start()
        {
            Initialize();
        }
        
        private void Initialize()
        {
            ObjectToScroll obj = null;
            ObjectToScroll prevObj = null;

            List<LevelChunk> _objectsToScroll = _chunkManager.Items.ToList();
            for (int i = 1; i < _objectsToScroll.Count; i++)
            {
                obj = _objectsToScroll[i].ObjectToScroll;
                prevObj = _objectsToScroll[i - 1].ObjectToScroll;
                obj.SetPreviousObject(prevObj);
                obj.AlignToNext();
            }

            obj = _objectsToScroll[0].ObjectToScroll;
            prevObj = _objectsToScroll[_objectsToScroll.Count - 1].ObjectToScroll;
            obj.SetPreviousObject(prevObj);
            obj.AlignToNext();

            var chunkNumb = _objectsToScroll.Count;
            var length = chunkNumb * _chunkSize;

            _startPosition.z = _startPoint.position.z;
            _endPosition.z = _endPoint.position.z; 
        }

        private void LateUpdate()
        {
            ScrollAnimation();
        }

        private void ScrollAnimation()
        {
            List<LevelChunk> _objectsToScroll = _chunkManager.Items.ToList();
            for (int i = 0; i < _objectsToScroll.Count; i++)
            {
                ObjectToScroll obj = _objectsToScroll[i].ObjectToScroll;
                Vector3 pos = obj.transform.localPosition;
                pos.z += _scrollSpeed * Time.deltaTime;
                if (pos.z < _endPosition.z)
                {
                    obj.AlignToNext();
                    return;
                }
                obj.transform.localPosition = pos;
            }
        }
    }
}
