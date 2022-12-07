using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Zenject;
using True10.LevelScrollSystem;

namespace DontStopTheTrain.Train
{
    public class WagonMovementData
    {

    }

    public class WagonRig
    {
        private Transform transform;
        private LocalJump localJump;
        private ShakeRotation shakeRotation;
        private PunchRotation punchRotation;
        private GoToZero goToZero;

        public WagonRig(Transform transform, 
            LocalJumpData localJumpData,
            ShakeRotationData shakeRotationData,
            PunchRotationData punchRotationData,
            GoToZeroData goToZeroData
            )
        {
            this.transform = transform;

            localJump = new LocalJump(localJumpData);
            shakeRotation = new ShakeRotation(shakeRotationData);
            punchRotation = new PunchRotation(punchRotationData);
            goToZero = new GoToZero(goToZeroData);
        }

        public void SimulateMovement(float multiplayer)
        {
            shakeRotation.Do(transform, multiplayer);
            punchRotation.Do(transform, multiplayer);
            localJump.Do(transform, multiplayer);
            goToZero.Do(transform, multiplayer);
        }
    }

    public class TrainMovementSimulationSystem : MonoBehaviour
    {
        [Inject]
        private ILevelScrollSpeedController levelScrollSpeedController;

        [SerializeField] private LocalJumpData localJumpData;
        [SerializeField] private ShakeRotationData shakeRotationData;
        [SerializeField] private PunchRotationData punchRotationData;
        [SerializeField] private GoToZeroData goToZeroData;
        [SerializeField] private List<Transform> wagonRigsTransform;
        
        private List<WagonRig> wagonRigs = new();


        /*[SerializeField] private float xRotationLimit = 2f;
        [SerializeField] private float xDuration = 1f;

        [SerializeField] private float yRotationLimit = 2f;
        [SerializeField] private float yDuration = 1f;
        [SerializeField] private float zRotationLimit = 2f;

        [SerializeField] private float zDuration = 1f;
        */
        void Start() 
        {
            Init();
        }


        void Init()
        {
            for (int i = 0; i < wagonRigsTransform.Count; i++)
            {
                var t = wagonRigsTransform[i];
                var wagonRig = new WagonRig(t, localJumpData, shakeRotationData, punchRotationData, goToZeroData);
                wagonRigs.Add(wagonRig);
            }
        }

        private void Update()
        {
           Simulation();
        }

        void Simulation()
        {
            foreach (var wr in wagonRigs)
            {
                wr.SimulateMovement( levelScrollSpeedController.Multilplayer);
            }
        }
    }

    [System.Serializable]
    public class AbstractTransformModifierData
    {
        public bool IsEnable = false;
        public LoopType LoopType = LoopType.Restart;
        public float Duration = 1f;
    }

    [System.Serializable]
    public abstract class AbstractTransformModifier
    {
        protected bool isEnable = false;
        protected LoopType loopType = LoopType.Restart;
        protected float duration = 1f;

        protected Tween tween = null;
        protected float multiplayer;

        protected abstract void Modify(Transform target);
        protected abstract void Init(Transform target);

        public AbstractTransformModifier(AbstractTransformModifierData data)
        {
            isEnable = data.IsEnable;
            loopType = data.LoopType;
            duration = data.Duration;
        }

        public void Do(Transform target, float multiplayer)
        {
            if (isEnable == false)
            {
                return;
            }
            if (tween != null)
            {
                return;
            }
            this.multiplayer = multiplayer;
            Init(target);
            Modify(target);
        }


        protected void OnTweenComplete()
        {
            tween.Kill();
            tween = null;
        }
    }

    [System.Serializable]
    public class ShakeRotationData : AbstractTransformModifierData
    {
        public float Strength = 2f;
        public int Vibrato = 3;
        public float Randomness = 20f;
        public bool FadeOut = true;
    }

    [System.Serializable]
    public class ShakeRotation : AbstractTransformModifier
    {
        private float shakeStrength = 2f;
        private float shakeDuration = 1f;
        private int shakeVibrato = 3;
        private float shakeRandomness = 20f;
        private bool shakeFadeOut = true;

        public ShakeRotation(ShakeRotationData data) : base(data)
    {
            shakeStrength = data.Strength;
            shakeVibrato = data.Vibrato;
            shakeRandomness = data.Randomness;
            shakeFadeOut = data.FadeOut;
        }

        protected override void Modify(Transform target)
        {
            tween = target.DOShakeRotation(shakeDuration, shakeStrength * multiplayer, shakeVibrato, shakeRandomness, shakeFadeOut)
               //.SetLoops(-1, loopType);
               .OnComplete(OnTweenComplete);
        }

        protected override void Init(Transform target)
        {
            shakeDuration *= (1f + Random.Range(-0.2f, 0.2f));
            shakeRandomness *= (1f + Random.Range(-0.2f, 0.2f));
        }
    }

    [System.Serializable]
    public class PunchRotationData : AbstractTransformModifierData
    {
        public Vector3 PunchVector = Vector3.up;
        public int Vibrato = 3;
        public float Elasticity = 1f;
        public bool ShakeFadeOut = true;
    }

    [System.Serializable]
    public class PunchRotation : AbstractTransformModifier
    {
        private Vector3 punchVector = Vector3.up;
        private int vibrato = 3;
        private float elasticity = 1f;
        private bool shakeFadeOut = true;

        public PunchRotation(PunchRotationData data) : base(data)
    {
            punchVector = data.PunchVector;
            vibrato = data.Vibrato;
            elasticity = data.Elasticity;
            shakeFadeOut = data.ShakeFadeOut;
        }

        protected override void Modify(Transform target)
        {
            tween = target.DOPunchRotation(punchVector * multiplayer, duration, vibrato, elasticity)
               // .SetLoops(-1, loopType);
               .OnComplete( OnTweenComplete );
        }

        protected override void Init(Transform target)
        {
            punchVector *= (1f + Random.Range(-0.2f, 0.2f));
            duration *= (1f + Random.Range(-0.2f, 0.2f));
        }
    }

    [System.Serializable]
    public class LocalJumpData : AbstractTransformModifierData
    {
        public bool Snapping = true;
        public float JumpPower = 0.5f;
        public int NumJumps = 3;
    }

    [System.Serializable]
    public class LocalJump : AbstractTransformModifier
    {
        private bool snapping = true;
        private float jumpPower = 0.5f;
        private int numJumps = 3;

        public LocalJump(LocalJumpData data) : base(data)
        {
            snapping = data.Snapping;
            jumpPower = data.JumpPower;
            numJumps = data.NumJumps;
        }

        protected override void Modify(Transform target)
        {
            tween = target.DOLocalJump(Vector3.zero, jumpPower * multiplayer, numJumps, duration, snapping)
             //   .SetLoops(-1, loopType);
               .OnComplete(OnTweenComplete);
        }

        protected override void Init(Transform target)
        {
            jumpPower *= (1f + Random.Range(-0.2f, 0.2f));
            duration *= (1f + Random.Range(-0.2f, 0.2f));
        }
    }


    [System.Serializable]
    public class GoToZeroData : AbstractTransformModifierData
    {
        public bool Snapping = true;
        public RotateMode RotateMode = RotateMode.Fast;
    }

    [System.Serializable]
    public class GoToZero : AbstractTransformModifier
    {
        private bool snapping = true;
        private RotateMode rotateMode = RotateMode.Fast;
        Sequence sequence = null;
        public GoToZero(GoToZeroData data) : base(data)
        {
            snapping = data.Snapping;
            rotateMode = data.RotateMode;
        }
        protected override void Modify(Transform target)
        {
            sequence = DOTween.Sequence();

            sequence
                .Append(target.DOLocalMove(Vector3.zero, duration, snapping) )
                .Join(target.DOLocalRotate(Vector3.zero, duration, rotateMode))
               .OnComplete(OnTweenComplete);

            tween = sequence;
        }

        protected override void Init(Transform target)
        {

        }
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

