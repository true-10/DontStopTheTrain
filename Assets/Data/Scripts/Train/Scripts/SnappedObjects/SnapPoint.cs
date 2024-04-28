using UnityEngine;

namespace True10
{

    public class SnapPoint : MonoBehaviour
    {
        public enum SnapType
        {
            Level,
            Wagon,
        }

        [SerializeField]
        private SnapType _snapType = SnapType.Wagon;

        private void OnDrawGizmos()
        {
            Gizmos.color = GetColorByType(_snapType);
            Gizmos.DrawSphere(transform.position, 0.2f);
        }

        private Color GetColorByType(SnapType snapType)
        {
            switch (snapType)
            {
                case SnapType.Level:
                    return Color.black;
                case SnapType.Wagon:
                default:
                    return Color.green;

            }
        }
    }

}
