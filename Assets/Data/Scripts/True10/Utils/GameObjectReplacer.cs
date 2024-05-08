using System;
using UnityEngine;

namespace True10.Utils
{
    public class GameObjectReplacer
    {
        public static void Replace(GameObject target, GameObject prefab, Action<GameObject> onComplete = null)
        {
            var position = target.transform.position;
            var rotation = target.transform.rotation;
            var parent = target.transform.parent;
            var newObject = GameObject.Instantiate(prefab, position, rotation, parent);
            GameObject.Destroy(target);
            onComplete?.Invoke(newObject);
        }
    }
}
