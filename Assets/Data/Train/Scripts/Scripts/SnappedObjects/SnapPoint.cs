using UnityEngine;

namespace True10
{

    public class SnapPoint : MonoBehaviour
    {

        public enum SnapType
        {
            Level,
            Wagon,
            WagonCart_2x,
            WagonCart_3x,
        }

        public SnapType Type => _snapType;

        [SerializeField]
        private SnapType _snapType = SnapType.Wagon;

        [SerializeField]
        private float _gizmoSize = 0.2f;

        private void OnDrawGizmos()
        {
            Gizmos.color = GetColorByType(_snapType);
            Gizmos.DrawSphere(transform.position, _gizmoSize);
        }

        private Color GetColorByType(SnapType snapType)
        {
            switch (snapType)
            {
                case SnapType.Level:
                    return Color.black;
                case SnapType.WagonCart_2x:
                    return Color.blue;
                case SnapType.WagonCart_3x:
                    return Color.cyan;
                case SnapType.Wagon:
                default:
                    return Color.green;

            }
        }
    }

}
