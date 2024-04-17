using UnityEngine;
using Zenject;
using True10.LevelScrollSystem;

namespace DontStopTheTrain.Train
{
    public class TrainMovementSimulationSystem_ : MonoBehaviour
    {
       // [Inject]
        //private ILevelScrollSpeedController _levelScrollSpeedController;

        [SerializeField] 
        private TransformSimulationSystem _transformSimulationSystem;

        private void Start()
        {
            _transformSimulationSystem.Initialize();
        }

        private void Update()
        {
            _transformSimulationSystem.Simulation(1f);
        }

        private void OnDestroy()
        {
            _transformSimulationSystem.Dispose();
        }

    }    
}




