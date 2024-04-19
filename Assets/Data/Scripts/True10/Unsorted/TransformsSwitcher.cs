using System.Collections.Generic;
using System.Linq;
using True10.CameraSystem;
using True10.Extentions;
using UnityEngine;

namespace True10
{
    public class TransformsSwitcher : MonoBehaviour
    {
        [SerializeField]
        private SwitchMode _switchMode = SwitchMode.Random;
        [SerializeField]
        private List<Transform> _targetTransforms;
        [SerializeField]
        private List<Transform> _positionsTransforms;

        private List<Transform> _usedPositionsTransforms = new();

        public void SwitchTransforms()
        {
            _usedPositionsTransforms.Clear();
            if (_targetTransforms.Count == 0 || _positionsTransforms.Count == 0)
            {
                return;
            }
            foreach (var target in _targetTransforms)
            {
                var positionTransfrom = GetNextTransform(_switchMode);
                target.position = positionTransfrom.position;
                target.rotation = positionTransfrom.rotation;
                _usedPositionsTransforms.Add(positionTransfrom);
                if (_positionsTransforms.Count == _usedPositionsTransforms.Count)
                {
                    return;
                }
            }
        }

        private Transform GetNextTransform(SwitchMode mode)
        {
            switch (mode)
            {
                case SwitchMode.Line:
                case SwitchMode.Random:
                case SwitchMode.Weighted:
                default:
                    return GetRandomPositionTransform();
            }
        }
        private Transform GetRandomPositionTransform()
        {
            var transforms = _positionsTransforms
                .Where(tr => _usedPositionsTransforms.Contains(tr) == false)
                .ToList();
            return transforms.GetRandomElement();
        }

        private void OnDestroy()
        {
            _usedPositionsTransforms.Clear();
        }
    }
}
