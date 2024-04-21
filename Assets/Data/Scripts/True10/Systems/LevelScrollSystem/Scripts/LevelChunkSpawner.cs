using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

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
        [Inject]
        private LevelChunksManager _chunkManager;

        [SerializeField] private List<SpawnChunksData> _spawnData;

        public void SpawnChunks(BiomType biomType, Action<LevelChunk> onSpawn = null, Action OnComplete = null)
        {
            StartCoroutine(SpawnChunksCoroutine(biomType, onSpawn, OnComplete));
        }

        IEnumerator SpawnChunksCoroutine(BiomType biomType,Action<LevelChunk> onSpawn, Action OnComplete)
        {
            var spawnData = _spawnData.Where(sd => sd.Chunks.BiomType == biomType).ToList() ;
            foreach (SpawnChunksData chunk in spawnData)
            {
                var setOfChunk = chunk.Chunks;

                var count = chunk.Count;
                var root = chunk.Root;
                for (int i = 0; i < count; i++)
                {
                    var levelChunk = chunk.Chunks.CreateRandomChunk(root);
                    levelChunk.gameObject.SetActive(false);
                    _chunkManager.TryToAdd(levelChunk);
                    onSpawn?.Invoke(levelChunk);
                    yield return null;
                }
                yield return null;

            }
            yield return null;
            OnComplete?.Invoke();
        }
    }
}
