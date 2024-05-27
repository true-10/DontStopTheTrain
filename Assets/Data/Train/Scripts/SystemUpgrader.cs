using System;
using True10.Utils;
using UnityEngine;

namespace DontStopTheTrain.Train
{
    public class SystemUpgrader //SystemUpgrader
    {

        public WagonSystemVisualData CurrentPartStatic => _currentStatic;

        private GameObject _target;
        private WagonSystemVisualData _currentStatic;
        public void SetCurrentSystemStatic(WagonSystemVisualData wagonPartStaticData)
        {
            _currentStatic = wagonPartStaticData;
        }
        
        public void SetCurrentTarget(GameObject target)
        {
            _target = target;
        }

        public void Undo()
        {
            TryToReplace(_currentStatic);
        }

        public bool TryToUpgraged(WagonSystemVisualData wagonSystemStaticData)
        {
           // var prefab = wagonSystemStaticData.NextLevelStaticData.ConstructorPrefab;
            //GameObjectReplacer.Replace(_target, prefab, (go) => { });
            return false;
        }

        public void TryToReplace(WagonSystemVisualData wagonSystemStaticData)//, Action<GameObject> onComlete = null)
        {
            var prefab = wagonSystemStaticData.ConstructorPrefab;
            GameObjectReplacer.Replace(_target, prefab, OnReplacemenComplete);
        }

        private void OnReplacemenComplete(GameObject newObject)
        {
            SetCurrentTarget(newObject);
        }
    }
}
