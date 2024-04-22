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
        private float _endZ;

        public void SetSpeed(float speed)
        {
            _scrollSpeed = -speed;
        }

        public void SetEnd(float endZ)
        {
            _endZ = endZ;
        }

        public void ScrollAnimation()
        {
            List<LevelChunk> levelChunks = _chunkManager.GetActiveChunks().OrderBy(chunk => chunk.transform.position.z).ToList();
            if (levelChunks.Count == 0)
            {
                return;
            }
            ObjectToScroll obj = levelChunks[0].ObjectToScroll;
            Vector3 pos = obj.transform.localPosition;
            pos.z += _scrollSpeed * Time.deltaTime;
            obj.transform.localPosition = pos;
            if (pos.z < _endZ)
            {
                OnEndReached?.Invoke(obj);
            }
        }

        public void AlignAll()
        {
            List<LevelChunk> _objectsToScroll = _chunkManager.GetActiveChunks().OrderBy(chunk => chunk.transform.position.z).ToList();

            if (_objectsToScroll.Count < 2)
            {
                return;
            }

            for (int i = 1; i < _objectsToScroll.Count; i++)
            {
                var obj = _objectsToScroll[i].ObjectToScroll;
                obj.AlignToNext();
            }
        }
    }
}
