using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DontStopTheTrain
{

    public class AutoScrolledObject : MonoBehaviour
    {
        [SerializeField]
        private Transform _cachedTransform;
        [SerializeField]
        private Rigidbody _rigidbody;
        [SerializeField]
        private float speed;

        private Vector3 _startPos;

        private void Start()
        {
            _startPos = _cachedTransform.position;
        }

        public void Move()
        {
            _rigidbody.velocity = _cachedTransform.forward * speed * Time.fixedDeltaTime;
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void OnCollisionEnter(Collision collision)
        {
           // Debug.Log($"ScrolledObject: OnCollisionEnter collision = {collision.gameObject}");
            OnContact(collision.gameObject);
        }


        private void OnContact(GameObject gameObject)
        {
            _cachedTransform.position = _startPos;
        }
    }
}
