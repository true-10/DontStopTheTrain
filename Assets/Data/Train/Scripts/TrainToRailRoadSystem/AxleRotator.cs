using System.Collections;
using System.Collections.Generic;
using True10.LevelScrollSystem;
using UnityEngine;
using Zenject;

namespace DontStopTheTrain.Animation
{
    public class AxleRotator : MonoBehaviour
    {
        [Inject]
        private ILevelScrollSpeedController levelScrollSpeedController;

        public static float speed = -3f;

        private float multiplayer => levelScrollSpeedController != null ? levelScrollSpeedController.Multilplayer : 1f;
        private Transform cachedTransform;
        // Start is called before the first frame update
        void Start()
        {
            cachedTransform = GetComponent<Transform>();
        }

        void LateUpdate()
        {
            cachedTransform.Rotate(Vector3.right * speed * multiplayer * 360f* Time.deltaTime);
        }
    }
}
