using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static True10.SnapPoint;

namespace True10
{
    public class SnappedObject : MonoBehaviour
    {
        public List<SnapPoint> Points => _points;

        [SerializeField]
        private SnapType _snapPointsType = SnapType.Wagon;
        [SerializeField]
        private List<SnapPoint> _points;

        private void OnValidate()
        {
            _points = GetComponentsInChildren<SnapPoint>()
                .Where(snapPoint => snapPoint.Type == _snapPointsType)
                .ToList();
        }
    }
}
