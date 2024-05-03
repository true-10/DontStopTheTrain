using UnityEngine;
using Zenject;
using True10.Interfaces;

namespace True10.LevelScrollSystem
{
    public class LevelScrollController : AbstractGameLifeCycleBehaviour
    {
        [Inject]
        private LevelChunksManager _chunkManager;
        [Inject]
        private ChunkGiver _chunkGiver;
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
        [SerializeField]
        private ChunkType _currentChunkType = ChunkType.Simple;

        private float normalSpeed;
        private LevelChunk _currentChunk;
        private bool _tryToStopRewind = false;

        public void RequestForChunk(ChunkType chunkType)
        {
            _currentChunkType = chunkType;
            _tryToStopRewind = true;
        }

        public override void Initialize()
        {
            LevelInitializator levelInitializator = new(_spawner, _endPoint.position);
            levelInitializator.Initialize();

            _levelScroller.SetEnd(_endPoint.position.z);

            _levelScroller.OnEndReached += OnChunkEndReached;
            _dayTimeSystem.OnRewind += OnRewind;
            _chunkManager.OnChunkEnter += OnChunkEnter;
        }

        public override void Dispose()
        {
            _levelScroller.OnEndReached -= OnChunkEndReached;
            _dayTimeSystem.OnRewind -= OnRewind;
            _chunkManager.OnChunkEnter -= OnChunkEnter;
        }

        private void OnChunkEnter(LevelChunk chunk)
        {
            _currentChunk = chunk;
            if (_currentChunk.StaticData.Type != ChunkType.Simple && _tryToStopRewind == true)
            {
                _tryToStopRewind = false;
                _dayTimeSystem.StopRewind();
            }
        }

        private void OnRewind(bool isOnRewind)
        {
            if (isOnRewind)
            {
                normalSpeed = _levelScroller.ScrollSpeed;
                _levelScroller.SetSpeed(normalSpeed * 50f);
            }
            else
            {
                _levelScroller.SetSpeed(normalSpeed);
            }
        }

        private void OnChunkEndReached(ObjectToScroll objectToScroll)
        {
            _chunkGiver.OnChunkEndReached(objectToScroll, 
                _currentChunkType, 
                _startPoint.position, 
                () => 
                {
                    if (_currentChunkType != ChunkType.Simple)
                    {
                        _currentChunkType = ChunkType.Simple;
                    }
                });
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
