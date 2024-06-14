using System;
using True10.Utils;
using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.UIElements;

namespace True10.CameraSystem
{
    [CreateAssetMenu(fileName = "CameraRigComponentMoveAlongTheSpline", menuName = "True10/CameraSystem/RigComponents/MoveAlongSpline")]
    public sealed class CameraRigComponentMovementAlongSpline : AbstractCameraRigComponent
    {
        public enum MoveMode
        {
            Both,
            OnlyX,
            OnlyY
        }

        [SerializeField]
        private Vector3 _rotationOffset = new Vector3(0f, 90f, 0f);
        [SerializeField]
        private float _moveSpeed = 0.1f;
        [SerializeField]
        private MoveMode _moveMode = MoveMode.Both;

        private Transform cachedTransform;
        private SplineUpdater _splineUpdater;
        private SplineContainer _splineContainer;
        private float _currentT = 1f;

        public override void Initialize(ICameraHolder cameraHolder, ICameraInputReader cameraInputReader)
        {
            base.Initialize(cameraHolder, cameraInputReader);//, cameraRigControllerObject);
            cachedTransform = cameraHolder.CameraRig.Root;

           // _splineUpdater = cameraRigControllerObject.GetComponent<SplineUpdater>();
            _splineUpdater = cachedTransform.GetComponent<SplineUpdater>();

            _splineContainer = _splineUpdater.SplineContainer;
            _splineUpdater.OnUpdate += OnSplinePositionUpdate;
        }

        public override void UpdateRig()
        {
            var hValue = _cameraInputReader.Move.x;
            var vValue = _cameraInputReader.Move.y;

            switch (_moveMode)
            {
                case MoveMode.OnlyX:
                    vValue = 0f;
                    break;
                case MoveMode.OnlyY:
                    hValue = 0f;
                    break;
            }
            var deltaT = -hValue * _moveSpeed * Time.deltaTime;
            _currentT += deltaT;
            _currentT = Mathf.Clamp(_currentT, 0.01f, 0.99f);
           // Debug.Log($"hValue = {hValue} deltaT = {deltaT} _currentT = {_currentT}");
        }

        private void UpdatePosition()
        {
            _splineContainer.Evaluate(_currentT, out var position, out var forward, out var up);
            var lookRotation = Quaternion.LookRotation(forward, up);

            cachedTransform.rotation = lookRotation;
            cachedTransform.Rotate(_rotationOffset, Space.Self);
            cachedTransform.position = position;
        }

        private void OnDestroy()
        {
            _splineUpdater.OnUpdate -= OnSplinePositionUpdate;
        }

        private void OnSplinePositionUpdate()
        {
            UpdatePosition();
        }
    }
}
