using UnityEngine;
using True10.Interfaces;

namespace True10.LevelScrollSystem
{
    public class LevelInitializator : IGameLifeCycle
    {
        private LevelChunkSpawner _spawner;
        private LevelChunk _prevChunk; 
        private Vector3 _endPosition;

        public LevelInitializator(LevelChunkSpawner spawner, Vector3 endPosition)
        {
            _spawner = spawner;
            _endPosition = endPosition;
        }

        public void Initialize()
        {
            _spawner.SpawnChunks(BiomType.City, onSpawn: OnSpawn, OnComplete: OnCityChunkSpawned);
            _spawner.SpawnChunks(BiomType.Desert);
            _spawner.SpawnChunks(BiomType.Forest);
        }

        public void Dispose()
        {

        }


        private void OnSpawn(LevelChunk chunk)
        {
            if (chunk.StaticData.Type != ChunkType.Simple)
            {
                return;
            }
            chunk.gameObject.SetActive(true);
            if (_prevChunk != null)
            {
                chunk.ObjectToScroll.SetPreviousObject(_prevChunk.ObjectToScroll);
                chunk.ObjectToScroll.AlignToNext();
            }
            else
            {
                chunk.transform.position = _endPosition;
            }

            _prevChunk = chunk;
        }

        private void OnCityChunkSpawned()
        {

        }
    }
}
