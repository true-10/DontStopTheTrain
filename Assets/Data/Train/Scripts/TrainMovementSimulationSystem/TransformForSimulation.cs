using System.Collections.Generic;
using UnityEngine;

namespace DontStopTheTrain.Train
{
    public class TransformForSimulation
    {
        private Transform _transform;
        private List<AbstractTransformModifier> _modifiers;

        public TransformForSimulation(Transform transform, List<AbstractTransformModifier> modifiers)
        {
            _transform = transform;
            _modifiers = new();
            foreach (var modifier in modifiers)
            {
                var newModifier = GameObject.Instantiate(modifier);
                _modifiers.Add(newModifier);
            }
        }

        public void Simulate(float multiplayer)
        {
            foreach (var modifier in _modifiers)
            {
                modifier.Do(_transform, multiplayer);
            }
        }

        public void Dispose()
        {
            foreach (var modifier in _modifiers)
            {
                modifier.Dispose();
            }
        }
    }
}




