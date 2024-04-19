using UnityEngine;

namespace True10.Characters
{
    [System.Serializable]
    public class MovementPhysicsBased : IMovable
    {
        [SerializeField]
        private Rigidbody cachedRigidbody;

        public void Move(Vector3 direction)
        {

        }

        public void Rotate(Vector3 angles)
        {

        }
    }
}
