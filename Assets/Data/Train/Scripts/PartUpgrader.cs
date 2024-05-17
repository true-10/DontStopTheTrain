using System;
using True10.Utils;
using UnityEngine;

namespace DontStopTheTrain.Train
{
    public class PartUpgrader
    {

        public WagonPartStaticData CurrentPartStatic => _currentStatic;

        private GameObject _target;
        private WagonPartStaticData _currentStatic;
        public void SetCurrentPartStatic(WagonPartStaticData wagonPartStaticData)
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

        public bool TryToUpgraged(WagonPartStaticData wagonPartStaticData)
        {
            var prefab = wagonPartStaticData.NextLevelStaticData.ConstructorPrefab;
            GameObjectReplacer.Replace(_target, prefab, (go) => { });
            return false;
        }

        public void TryToReplace(WagonPartStaticData wagonPartStaticData)//, Action<GameObject> onComlete = null)
        {
            var prefab = wagonPartStaticData.ConstructorPrefab;
            GameObjectReplacer.Replace(_target, prefab, OnReplacemenComplete);
        }

        private void OnReplacemenComplete(GameObject newObject)
        {
            SetCurrentTarget(newObject);
        }
    }
}
