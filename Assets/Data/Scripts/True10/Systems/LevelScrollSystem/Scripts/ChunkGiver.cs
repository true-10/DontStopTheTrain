using UnityEngine;
using Zenject;
using System.Linq;
using System;

namespace True10.LevelScrollSystem
{
    public sealed class ChunkGiver
    {
        [Inject]
        private LevelChunksManager _chunkManager;

        private BiomType _currentBiomType = BiomType.City;
      //  private ChunkType _currentChunkType = ChunkType.Simple;

        int index = 0;

        public void OnChunkEndReached(ObjectToScroll objectToScroll, ChunkType currentChunkType, Vector3 startPosition, Action onComlete = null)
        {
            index++;
            var remainder = index % 5;// 10;
            if (remainder == 0)
            {
                remainder = UnityEngine.Random.Range(0, 3);
                switch (remainder)
                {
                    case 0:
                    default:
                        _currentBiomType = BiomType.City;
                        break;
                    case 1:
                        _currentBiomType = BiomType.Desert;
                        break;
                    case 2:
                        _currentBiomType = BiomType.Forest;
                        break;
                }
                //  _currentBiomType = (remainder == 1) ? BiomType.Desert : BiomType.City;
                //  Debug.Log($"_currentBiomType = {_currentBiomType} index = {index}");
            }
            objectToScroll.gameObject.SetActive(false);
            var orderedChunkbyZPos = _chunkManager.GetActiveChunks().OrderBy(chunk => chunk.transform.position.z);
            var lastChunk = orderedChunkbyZPos.LastOrDefault();
            if (lastChunk == null)
            {
                Debug.Log($"lastChunk == null");
                return;
            }
            var newChunk = _chunkManager.GetRandomWeightedChunk(_currentBiomType, currentChunkType);
            if (newChunk == null)
            {
                Debug.Log($"newChunk == null");
                return;
            }
            var obj = newChunk.ObjectToScroll;
            newChunk.gameObject.SetActive(true);
            obj.SetPreviousObject(lastChunk.ObjectToScroll);
            obj.AlignToNext();

            objectToScroll.transform.position = startPosition;
            onComlete?.Invoke();           
        }
    }
}
