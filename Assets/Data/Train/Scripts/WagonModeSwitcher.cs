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

    public class WagonModeSwitcher : MonoBehaviour
    {
        [SerializeField]
        private WagonSystemsContainer _container;

        private ViewMode _currentMode = ViewMode.Game;


        public void SwitchTo(ViewMode newMode)
        {
            _currentMode = newMode;
        }

        private void OnValidate()
        {
            _container ??= GetComponent<WagonSystemsContainer>();
        }

        public void SwitchToGameMode()
        {
            var holders = _container.SystemNotEmptyHolders;
            foreach (var holder in holders)
            {
                var wagonSystemObject = holder.WagonSystemObject;
                var wagonSystemStaticData = holder.WagonSystemObject.StaticData;
                var gamePrefab = wagonSystemStaticData.WagonPartStaticData.GamePrefab;
            }
        }

        public void SwitchToConstructorMode()
        {

        }
    }

}
