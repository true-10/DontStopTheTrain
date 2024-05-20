using System;
using True10.Utils;
using UnityEngine;

namespace DontStopTheTrain.Train
{
    public class SystemUpgrader //SystemUpgrader
    {

        public WagonPartStaticData CurrentPartStatic => _currentStatic;

        private GameObject _target;
        private WagonPartStaticData _currentStatic;
        public void SetCurrentSystemStatic(WagonPartStaticData wagonPartStaticData)
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

        public bool TryToUpgraged(WagonPartStaticData wagonSystemStaticData)
        {
            var prefab = wagonSystemStaticData.NextLevelStaticData.ConstructorPrefab;
            GameObjectReplacer.Replace(_target, prefab, (go) => { });
            return false;
        }

        public void TryToReplace(WagonPartStaticData wagonSystemStaticData)//, Action<GameObject> onComlete = null)
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
