using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace DontStopTheTrain.Train
{
    public class WagonMovementData
    {

    }

    public class TrainMovementSimulationSystem : MonoBehaviour
    {
        [SerializeField] List<Transform> wagonRigs;

        [SerializeField] private float shakeStrength = 2f;
        [SerializeField] private float shakeDuration = 1f;
        [SerializeField] private int shakeVibrato = 3;
        [SerializeField] private float shakeRandomness = 20f;
        [SerializeField] private bool shakeFadeOut = true;
        [SerializeField] private LoopType shakeLoopType = LoopType.Restart;

        /*[SerializeField] private float xRotationLimit = 2f;
        [SerializeField] private float xDuration = 1f;

        [SerializeField] private float yRotationLimit = 2f;
        [SerializeField] private float yDuration = 1f;
        [SerializeField] private float zRotationLimit = 2f;

        [SerializeField] private float zDuration = 1f;
        */
        void Start()
        {
            Simulation();
        }

        // Update is called once per frame
        void LateUpdate()
        {

        }
        void Simulation()
        {
            foreach (Transform t in wagonRigs)
            {
                SimulateMovement(t);
            }
        }

        void SimulateMovement(Transform target)
        {
            ShakeRotation(target);
            //Rotation(target);
        }

        void ShakeRotation(Transform target)
        {
            target.DOShakeRotation(shakeDuration, shakeStrength, shakeVibrato, shakeRandomness, shakeFadeOut)
                .SetLoops(-1, LoopType.Yoyo);
        }

        /*void Rotation(Transform target)
        {
            //xAngle = 
            //     DOTween.To(() => xAngle, x => xAngle, xRotationLimit, xDuration);
            XRotation(target);
            YRotation(target);
            ZRotation(target);
        }

        
        void XRotation(Transform target)
        {
            InitRandomXRotation(target);
            var endRotation = Vector3.zero;
            endRotation.x = xRotationLimit;
            target.DOLocalRotate(endRotation, xDuration)
                .SetLoops(-1, LoopType.Yoyo);
        }

        void YRotation(Transform target)
        {
            InitRandomZRotation(target);
            var endRotation = Vector3.zero;
            endRotation.y = yRotationLimit;
            // target.DOLocalRotate(endRotation, yDuration)
            // .SetLoops(-1, LoopType.Yoyo);
            target.DOShakeRotation(yDuration);
        }

        void ZRotation(Transform target)
        {
            InitRandomZRotation(target);
            var endRotation = Vector3.zero;
            endRotation.z = zRotationLimit;
            target.DOLocalRotate(endRotation, zDuration)
                .SetLoops(-1, LoopType.Yoyo);
        }

        void InitRandomXRotation(Transform target)
        {
            var endRotation = Vector3.zero;
            endRotation.x = Random.Range(-xRotationLimit, xRotationLimit);
            target.DORotate(endRotation, 0);
        }

        void InitRandomYRotation(Transform target)
        {
            var endRotation = Vector3.zero;
            endRotation.y = Random.Range(-yRotationLimit, yRotationLimit);
            target.DORotate(endRotation, 0);
        }

        void InitRandomZRotation(Transform target)
        {
            var endRotation = Vector3.zero;
            endRotation.z = Random.Range(-zRotationLimit, zRotationLimit);
            target.DORotate(endRotation, 0);
        }*/
    }

}
