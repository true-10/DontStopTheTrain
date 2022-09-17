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
        [SerializeField] private LocalJump localJump = new LocalJump();
        [SerializeField] private ShakeRotation shakeRotation = new ShakeRotation();
        [SerializeField] private PunchRotation punchRotation = new PunchRotation();
        [SerializeField] private GoToZero goToZero = new GoToZero();
        [SerializeField] List<Transform> wagonRigs;


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


        void Simulation()
        {
            foreach (Transform t in wagonRigs)
            {
                SimulateMovement(t);
            }
        }

        void SimulateMovement(Transform target)
        {
            shakeRotation.Do(target);
            punchRotation.Do(target);
            localJump.Do(target);
            goToZero.Do(target);
            //Rotation(target);
        }




        [System.Serializable]
        public abstract class AbstractTransformModifier
        {
            public bool isEnable = false;
            public LoopType loopType = LoopType.Restart;

            public void Do(Transform target)
            {
                if (isEnable == false)
                {
                    return;
                }
                Init(target);
                Modify(target);
            }

            protected virtual void Modify(Transform target)
            {

            }

            protected virtual void Init(Transform target)
            {

            }

        }

        [System.Serializable]
        public class ShakeRotation : AbstractTransformModifier
        {

            [SerializeField] private float shakeStrength = 2f;
            [SerializeField] private float shakeDuration = 1f;
            [SerializeField] private int shakeVibrato = 3;
            [SerializeField] private float shakeRandomness = 20f;
            [SerializeField] private bool shakeFadeOut = true;


            protected override void Modify(Transform target)
            {

                target.DOShakeRotation(shakeDuration, shakeStrength, shakeVibrato, shakeRandomness, shakeFadeOut)
                    .SetLoops(-1, loopType);
            }

            protected override void Init(Transform target)
            {
                shakeDuration *= (1f + Random.Range(-0.2f, 0.2f));
                shakeRandomness *= (1f + Random.Range(-0.2f, 0.2f));
            }
        }

        [System.Serializable]
        public class PunchRotation : AbstractTransformModifier
        {

            [SerializeField] private Vector3 punchVector = Vector3.up;
            [SerializeField] private float duration = 1f;
            [SerializeField] private int vibrato = 3;
            [SerializeField] private float elasticity = 1f;
            [SerializeField] private bool shakeFadeOut = true;

            protected override void Modify(Transform target)
            {
                target.DOPunchRotation(punchVector, duration, vibrato, elasticity)
                    .SetLoops(-1, loopType);
            }

            protected override void Init(Transform target)
            {

                punchVector *= (1f + Random.Range(-0.2f, 0.2f));
                duration *= (1f + Random.Range(-0.2f, 0.2f));
            }
        }

        [System.Serializable]
        public class LocalJump : AbstractTransformModifier
    {
            public bool snapping = true;
            public float duration = 1f;
            public float jumpPower = 0.5f;
            public int numJumps = 3;

            protected override void Modify(Transform target)
            {
                target.DOLocalJump(Vector3.zero, jumpPower, numJumps, duration, snapping)
                    .SetLoops(-1, loopType);
            }

            protected override void Init(Transform target)
            {
                jumpPower *= (1f + Random.Range(-0.2f, 0.2f));
                duration *= (1f + Random.Range(-0.2f, 0.2f));
            }
        }



        [System.Serializable]
        public class GoToZero : AbstractTransformModifier
        {
            public bool snapping = true;
            public float duration = 1f;

            protected override void Modify(Transform target)
            {
                target.DOLocalMove(Vector3.zero, duration, snapping )
                    .SetLoops(-1, loopType);
            }

            protected override void Init(Transform target)
            {

            }
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
