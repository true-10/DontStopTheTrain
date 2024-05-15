using System;
using True10.Utils;
using UnityEngine;

namespace DontStopTheTrain.Train
{
    public class WagonPartReplacerTest : MonoBehaviour
    {
        [SerializeField]
        private GameObject _prefab1;
        [SerializeField]
        private GameObject _prefab2;
        [SerializeField]
        private GameObject _target;

        int index = 1;
        public void ReplaceWithPrefab() 
        {
            if (index == 1)
            {
                GameObjectReplacer.Replace(_target, _prefab1, OnReplacementComplete);
                index = 2;
            }
            else
            if (index == 2)
            {
                GameObjectReplacer.Replace(_target, _prefab2, OnReplacementComplete);
                index = 1;
            }
        }

        private void OnReplacementComplete(GameObject newTarget)
        {
            _target = newTarget;
        }
    }
}
