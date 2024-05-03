using UnityEngine;

namespace True10
{

    public class SnapPoint : MonoBehaviour
    {
        public enum SnapType
        {
            Level,
            Wagon,
            WagonCart,
        }

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
                case SnapType.WagonCart:
                    return Color.blue;
                case SnapType.Wagon:
                default:
                    return Color.green;

            }
        }
    }

}
