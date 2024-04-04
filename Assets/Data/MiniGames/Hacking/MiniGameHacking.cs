using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using True10.Interfaces;
using UnityEngine;

namespace DontStopTheTrain.MiniGames
{

    public class MiniGameHacking : MonoBehaviour, IGameLifeCycle
    {
        public Action<HackingElement> OnElementRotate { get; set; }

        [SerializeField]
        private HackingElementView _startConnector;
        [SerializeField]
        private HackingElementView _endConnector;
        [SerializeField]
        private List<HackingElementView> _elementViews;

        public void Initialize()
        {
            foreach (var view in _elementViews)
            {
                view.Element.OnRotate += ElementRotation;
            }
        }

        public void Dispose()
        {
            foreach (var view in _elementViews)
            {
                view.Element.OnRotate -= ElementRotation;
            }
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

        }

        private void ElementRotation(HackingElement element)
        {
            OnElementRotate?.Invoke(element);
            TryToComplete();
        }

        private void Start()
        {
            Initialize();
        }

        private void OnDestroy()
        {
            Dispose();
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
