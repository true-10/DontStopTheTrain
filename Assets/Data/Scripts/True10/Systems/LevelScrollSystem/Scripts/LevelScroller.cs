using System.Collections.Generic;
using UnityEngine;
using Zenject;
using System;
using System.Linq;

namespace True10.LevelScrollSystem
{
    public class LevelScroller
    {
        public Action<ObjectToScroll> OnEndReached { get; set; }
        public float ScrollSpeed => Mathf.Abs(_scrollSpeed);

        [Inject]
        private LevelChunksManager _chunkManager;

        private float _scrollSpeed = 200f;

        public void SetSpeed(float speed)
        {
            _scrollSpeed = -speed;
        }

        public void ScrollAnimation(float endZ)
        {
            List<LevelChunk> _objectsToScroll = _chunkManager.GetActiveChunks();
            for (int i = 0; i < _objectsToScroll.Count; i++)
            {
                ObjectToScroll obj = _objectsToScroll[i].ObjectToScroll;
                Vector3 pos = obj.transform.localPosition;
                pos.z += _scrollSpeed * Time.deltaTime;
                if (pos.z < endZ)
                {
                    OnEndReached?.Invoke(obj);
                    return;
                }
                obj.transform.localPosition = pos;
            }
        }


        public void ScrollAnimation2(float endZ)
        {
            List<LevelChunk> _objectsToScroll = _chunkManager.GetActiveChunks().OrderBy(chunk => chunk.transform.position.z).ToList();

            if (_objectsToScroll.Count == 0)
            {
                return;
            }
            ObjectToScroll obj = _objectsToScroll[0].ObjectToScroll;
            Vector3 pos = obj.transform.localPosition;
            pos.z += _scrollSpeed * Time.deltaTime;
            if (pos.z < endZ)
            {
                OnEndReached?.Invoke(obj);
                return;
            }
            obj.transform.localPosition = pos;

            for (int i = 1; i < _objectsToScroll.Count; i++)
            {
                obj = _objectsToScroll[i].ObjectToScroll;
                obj.AlignToNext();
            }
        }
    }
}
