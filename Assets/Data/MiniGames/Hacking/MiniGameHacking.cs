using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DontStopTheTrain.MiniGames
{
    public class MiniGameHacking : AbstractMiniGame
    {
        public Action<HackingElement> OnElementRotate { get; set; }

        [SerializeField]
        private GameObject _root;
        [SerializeField]
        private HackingElementView _startConnector;
        [SerializeField]
        private HackingElementView _endConnector;
        [SerializeField]
        private List<HackingElementView> _elementViews;

        public override void StartMiniGame()
        {
            _root.SetActive(true);
            _cameraHolder.SwitchToThisCamera();
        }

        public override void StopMiniGame()
        {
            _root.SetActive(false);
            _cameraHolder.SwitchToDefaultCamera();
        }

        public override void Initialize()
        {
            _root.SetActive(false);
            _startConnector.Initialize();
            _endConnector.Initialize();
            foreach (var view in _elementViews)
            {
                view.Initialize();
                view.Element.OnRotate += ElementRotation;
            }
        }

        public override void Dispose()
        {
            foreach (var view in _elementViews)
            {
                view.Element.OnRotate -= ElementRotation;
                view.Dispose();
            }
            _startConnector.Dispose();
            _endConnector.Dispose();
        }

        private void TryToComplete()
        {
            var firstElement = _elementViews.FirstOrDefault();

            bool result = ConnectorService.IsConnected(_startConnector.Element, firstElement.Element);
            for(int i = 0; i < _elementViews.Count - 1; i++)
            {
                var view = _elementViews[i];
                var next = _elementViews[i + 1];

                result &= ConnectorService.IsConnected(view.Element, next.Element);
            }

            var lastElement = _elementViews.LastOrDefault();
            result &= ConnectorService.IsConnected(_endConnector.Element, lastElement.Element);

            Debug.Log($"Hacking result is {result}");
            if (result == true)
            {
                //delay for animation ending
                StopMiniGame();
                OnComplete?.Invoke(this);
            }

        }

        private void ElementRotation(HackingElement element)
        {
            OnElementRotate?.Invoke(element);
            TryToComplete();
        }
    }

    public enum ConnectorPosition
    {
        Right = 0,
        Left,
        Top,
        Bottom
    }
}
