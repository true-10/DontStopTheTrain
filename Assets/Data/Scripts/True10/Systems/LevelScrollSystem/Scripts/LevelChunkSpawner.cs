using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace True10.LevelScrollSystem
{
    [System.Serializable]
    public class SpawnChunksData
    {
        public SetOfChunks Chunks;
        public Transform Root;
        public int Count;
    }

    public class LevelChunkSpawner : MonoBehaviour
    {
        [SerializeField] private List<SpawnChunksData> _spawnData;

        public void SpawnChunks(Action OnComplete)
        {
            StartCoroutine(SpawnChunksCoroutine(OnComplete));
        }

        IEnumerator SpawnChunksCoroutine(Action OnComplete)
        {
            foreach (SpawnChunksData chunk in _spawnData)
            {
                var setOfChunk = chunk.Chunks;

                var count = chunk.Count;
                var root = chunk.Root;
                for (int i = 0; i < count; i++)
                {
                    chunk.Chunks.CreateRandomChunk(root);

                    yield return null;
                }
                yield return null;

            }
            yield return null;
            OnComplete?.Invoke();
        }
    }
}
