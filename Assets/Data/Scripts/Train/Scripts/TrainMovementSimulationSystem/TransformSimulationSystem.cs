using System.Collections.Generic;
using True10.Interfaces;
using UnityEngine;

namespace DontStopTheTrain.Train
{
    public class TransformSimulationSystem : MonoBehaviour, IGameLifeCycle
    {
        [SerializeField]
        private List<AbstractTransformModifier> _modifiers;
        [SerializeField] 
        private List<Transform> _transforms;

        private List<TransformForSimulation> _transformsForSimulation;

        public void Initialize()
        {
            _transformsForSimulation = new();
            foreach (var tr in _transforms)
            {
                AddTransformForSimulation(tr);
            }
        }

        public void Dispose()
        {
            foreach (var tr in _transformsForSimulation)
            {
                tr.Dispose();
            }
        }

        public void AddTransform(Transform newTransform)
        {
            if (_transforms.Contains(newTransform))
            {
                return;
            }
            _transforms.Add(newTransform);
            AddTransformForSimulation(newTransform);
        }

        public void Simulation(float multiplayer)
        {
            foreach (var tr in _transformsForSimulation)
            {
                tr.Simulate(multiplayer);
            }
        }

        private void AddTransformForSimulation(Transform tr)
        {
            var transformForSimulation = new TransformForSimulation(tr, _modifiers);
            _transformsForSimulation.Add(transformForSimulation);
        }
    }
}




