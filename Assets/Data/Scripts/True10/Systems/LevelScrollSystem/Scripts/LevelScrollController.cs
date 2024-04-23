using System.Collections.Generic;
using UnityEngine;
using Zenject;
using System.Linq;
using System;
using True10.Interfaces;
using True10.DayTimeSystem;

namespace True10.LevelScrollSystem
{
    public class LevelScrollController : AbstractGameLifeCycleBehaviour
    {
        [Inject]
        private LevelChunksManager _chunkManager;
        [Inject]
        private LevelScroller _levelScroller;
        [Inject]
        private DayTimeSystem.DayTimeSystem _dayTimeSystem;

        [SerializeField]
        private LevelChunkSpawner _spawner;
        [SerializeField]
        private Transform _startPoint;
        [SerializeField]
        private Transform _endPoint;
        [SerializeField]
        private BiomType _currentBiomType = BiomType.City;

        private float normalSpeed;

        public override void Initialize()
        {
            _spawner.SpawnChunks(BiomType.City, onSpawn: OnSpawn, OnComplete: OnCityChunkSpawned);
            _spawner.SpawnChunks(BiomType.Desert);
            _spawner.SpawnChunks(BiomType.Forest);

            _levelScroller.SetEnd(_endPoint.position.z);

            _levelScroller.OnEndReached += OnChunkEndReached;
            _dayTimeSystem.OnStartRewind += OnStartRewind;
            _dayTimeSystem.OnEndRewind += OnEndRewind;


        }


        public override void Dispose()
        {
            _levelScroller.OnEndReached -= OnChunkEndReached;
            _dayTimeSystem.OnStartRewind -= OnStartRewind;
            _dayTimeSystem.OnEndRewind -= OnEndRewind;
        }

        private void OnStartRewind()
        {
            normalSpeed = _levelScroller.ScrollSpeed;
            _levelScroller.SetSpeed(normalSpeed * 50f);
        }

        private void OnEndRewind()
        {
            _levelScroller.SetSpeed(normalSpeed);
        }

        private void OnCityChunkSpawned()
        {

        }

        int index = 0;
        private void OnChunkEndReached(ObjectToScroll objectToScroll)
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
                Debug.Log($"_currentBiomType = {_currentBiomType} index = {index}");
            }
            objectToScroll.gameObject.SetActive(false);
            var orderedChunkbyZPos = _chunkManager.GetActiveChunks().OrderBy(chunk => chunk.transform.position.z);
            var lastChunk = orderedChunkbyZPos.LastOrDefault();
            if (lastChunk == null)
            {
                Debug.Log($"lastChunk == null");
                return;
            }
            var newChunk = _chunkManager.GetRandomWeightedChunk(_currentBiomType);
            if (newChunk == null)
            {
                Debug.Log($"newChunk == null");
                return;
            }
            var obj = newChunk.ObjectToScroll;
            newChunk.gameObject.SetActive(true);
            obj.SetPreviousObject(lastChunk.ObjectToScroll);
            obj.AlignToNext();

            objectToScroll.transform.position = _startPoint.position;
        }

        private LevelChunk prevChunk;
        private void OnSpawn(LevelChunk chunk)
        {
            chunk.gameObject.SetActive(true);
            if (prevChunk != null)
            {
                chunk.ObjectToScroll.SetPreviousObject(prevChunk.ObjectToScroll);
                chunk.ObjectToScroll.AlignToNext();
            }
            else
            {
                chunk.transform.position = _endPoint.position;
            }

            prevChunk = chunk;
        }

        private void Update()
        {
            _levelScroller.ScrollAnimation();
        }

        private void LateUpdate()
        {
            _levelScroller.AlignAll();
        }

    }
}
