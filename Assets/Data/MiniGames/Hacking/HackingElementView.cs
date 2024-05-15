using DG.Tweening;
using System;
using True10;
using True10.Interfaces;
using UnityEngine;

namespace DontStopTheTrain.MiniGames
{
    public class HackingElementView : MonoBehaviour, IGameLifeCycle
    {
        public HackingElement Element => _element;

        [SerializeField]
        private ConnectorPosition _connectorAStartPosition;
        [SerializeField]
        private ConnectorPosition _connectorBStartPosition;
        [Header("Connector's available positions")]
        [SerializeField]
        private Transform _rightTransform;
        [SerializeField]
        private Transform _leftTransform;
        [SerializeField]
        private Transform _topTransform;
        [SerializeField]
        private Transform _bottomTransform;
        [Header("Connector's visual")]
        [SerializeField]
        private Transform _connectorATransform;
        [SerializeField]
        private Transform _connectorBTransform;
        [Header("Other")]
        [SerializeField]
        private float _rotationDuration = 0.3f;
        [SerializeField]
        private ClickOnObject _clickOnObject;

        private HackingElement _element;
        private Transform _cachedTransform;
        private bool _isClickable = true;


        public void Initialize()
        {
            _element = new(_connectorAStartPosition, _connectorBStartPosition);
            _element.OnRotate += OnElementRotation;

            _clickOnObject ??= GetComponent<ClickOnObject>();
            _cachedTransform ??= GetComponent<Transform>();
            _clickOnObject.OnClick += OnClickHandler;

            SetupVisualsOnStart();
        }

        public void Dispose()
        {
            _element.OnRotate -= OnElementRotation;
            _clickOnObject.OnClick -= OnClickHandler;
        }

        private void OnElementRotation(HackingElement element)
        {
            //поворачиваем на 90 градусов
            var eulers = _cachedTransform.eulerAngles + Vector3.up * 90f;
            _cachedTransform.DORotate(eulers, _rotationDuration)
                .OnComplete( () => { _isClickable = true; });
        }

        private void OnClickHandler()
        {
            if (_isClickable == false)
            {
                return;
            }
            _isClickable = false;
            _element.Rotate();
        }

        private void SetupVisualsOnStart()
        {
            var transformA = GetTransform(_connectorAStartPosition);
            _connectorATransform.position = transformA.position;
            _connectorATransform.rotation = transformA.rotation;

            var transformB = GetTransform(_connectorBStartPosition);
            _connectorBTransform.position = transformB.position;
            _connectorBTransform.rotation = transformB.rotation;
        }

        private Transform GetTransform(ConnectorPosition connector)
        {
            switch (connector)
            {
                case ConnectorPosition.Right:
                    return _rightTransform;
                case ConnectorPosition.Left:
                    return _leftTransform;
                case ConnectorPosition.Top:
                    return _topTransform;
                case ConnectorPosition.Bottom:
                    return _bottomTransform;
            }
            return null;
        }

        private void OnValidate()
        {
            if (_connectorAStartPosition == _connectorBStartPosition)
            {
                _connectorBStartPosition = ConnectorService.GetOpposite(_connectorAStartPosition);
            }
            _clickOnObject ??= GetComponent<ClickOnObject>();
            _cachedTransform ??= GetComponent<Transform>();
        }

      /*  private void Start()
        {
            Initialize();
        }

        private void OnDestroy()
        {
            Dispose();
        }*/
    }
}
