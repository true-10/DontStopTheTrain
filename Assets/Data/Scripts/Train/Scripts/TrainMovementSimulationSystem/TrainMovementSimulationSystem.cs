using UnityEngine;
using Zenject;

namespace DontStopTheTrain.Train
{
    public class TrainMovementSimulationSystem_ : MonoBehaviour
    {
        [Inject]
        private WagonsManager _wagonsManager;

        [SerializeField] 
        private TransformSimulationSystem _transformSimulationSystem;

        private Locomotive _locomotive;
        private float _multiplayer => _locomotive == null ? 1f : _locomotive.SpeedMultiplayer;

        private void Start()
        {
            _locomotive = _wagonsManager.GetLocomotive();
            _transformSimulationSystem.Initialize();
        }

        private void Update()
        {
            _locomotive ??= _wagonsManager.GetLocomotive();
            _transformSimulationSystem.Simulation(_multiplayer);
        }

        private void OnDestroy()
        {
            _transformSimulationSystem.Dispose();
        }
    }    
}