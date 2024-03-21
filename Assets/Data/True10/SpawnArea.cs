using UnityEngine;

namespace True10
{
    [RequireComponent(typeof(BoxCollider))]
    public sealed class SpawnArea : MonoBehaviour
    {
        private BoxCollider _boxCollider;

        private Bounds bounds => _boxCollider.bounds;

        public Vector3 GetRandomPosition()
        {
            Vector3 randomPosition = transform.position;

            var randomX = Random.Range(-bounds.extents.x, bounds.extents.x);
            var randomZ = Random.Range(-bounds.extents.z, bounds.extents.z);
            randomPosition.x += randomX;
            randomPosition.z += randomZ;

            return randomPosition;
        }

        private void OnValidate()
        {
            _boxCollider ??= GetComponent<BoxCollider>();
        }

        private void Start()
        {
            _boxCollider ??= GetComponent<BoxCollider>();
        }
    }
}
