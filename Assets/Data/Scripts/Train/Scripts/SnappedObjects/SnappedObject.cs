using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace True10
{
    public class SnappedObject : MonoBehaviour
    {
        public List<SnapPoint> Points => _points;

        [SerializeField]
        private List<SnapPoint> _points;

        private void OnValidate()
        {
            _points = GetComponentsInChildren<SnapPoint>().ToList();
        }
    }
}
