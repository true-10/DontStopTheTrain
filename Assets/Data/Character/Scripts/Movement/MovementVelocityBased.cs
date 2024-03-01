using UnityEngine;

namespace True10.Characters
{

    [System.Serializable]
    public class MovementVelocityBased : IMovable
    {
        [SerializeField]
        private Rigidbody cachedRigidbody;
        [SerializeField]
        private float speed = 5;
        [SerializeField]
        private float rotationSpeed = 100f;
        [SerializeField]
        private float gravity = -9.81f;

        public void Move(Vector3 direction)
        {
            var prevVelocity = cachedRigidbody.velocity;
            var newVelocity = cachedRigidbody.transform.forward * direction.z * speed;
            newVelocity.y = prevVelocity.y + gravity * Time.fixedDeltaTime;
            if (Physics.Raycast(cachedRigidbody.position + Vector3.up, Vector3.down, out var hitInfo))
            {
                newVelocity += cachedRigidbody.GetPointVelocity(hitInfo.point);
                /*var rb = hitInfo.rigidbody;
                if (rb != null)
                {
                    newVelocity += rb.GetPointVelocity(hitInfo.point);
                }*/
            }
            cachedRigidbody.velocity = newVelocity;
        }

        public void Rotate(Vector3 angles)
        {
            var angle = cachedRigidbody.rotation.eulerAngles.y + rotationSpeed * angles.x * Time.fixedDeltaTime;
            Quaternion deltaRotation = Quaternion.AngleAxis(angle, cachedRigidbody.transform.up);
            cachedRigidbody.MoveRotation(deltaRotation);
        }
    }
}
