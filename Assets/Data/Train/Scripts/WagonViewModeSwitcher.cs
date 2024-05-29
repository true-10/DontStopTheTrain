using DontStopTheTrain.Train.Constructor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DontStopTheTrain.Train
{
    public enum ViewMode
    {
        Game = 0,
        Constructor = 1
    }

    public class WagonViewModeSwitcher : MonoBehaviour
    {
        [SerializeField]
        private WagonSystemsContainer _container;
        [SerializeField]
        private GameObject _gameViewObject;
        [SerializeField]
        private GameObject _constructorViewObject;

        private ViewMode _currentMode = ViewMode.Game;

        private void OnValidate()
        {
            _container ??= GetComponent<WagonSystemsContainer>();
        }
        private void Start()
        {
            SwitchWagonToGameMode();
            SwitchSystemsToGameMode();
        }
        public void SwitchWagonToConstructorMode()
        {
            _gameViewObject.SetActive(false);
            _constructorViewObject.SetActive(true);
        }

        public void SwitchWagonToGameMode()
        {
            _gameViewObject.SetActive(true);
            _constructorViewObject.SetActive(false);
        }

        public void SwitchSystemsToGameMode()
        {
            _currentMode = ViewMode.Game;
            var holders = _container.SystemNotEmptyHolders;
            foreach (var holder in holders)
            {
                var wagonSystemObject = holder.WagonSystemObject;
                if (wagonSystemObject.TryGetComponent<SystemViewModeSwitcher>(out var visualObject))
                {
                    visualObject.SwitchToGameMode();
                }
            }
        }

        public void SwitchSystemsToConstructorMode()
        {
            _currentMode = ViewMode.Constructor;
            var holders = _container.SystemNotEmptyHolders;
            foreach (var holder in holders)
            {
                var wagonSystemObject = holder.WagonSystemObject;
                if (wagonSystemObject.TryGetComponent<SystemViewModeSwitcher>(out var visualObject))
                {
                    visualObject.SwitchToConstructorMode();
                }
            }
        }
    }

}
