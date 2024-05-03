using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace DontStopTheTrain.Train
{
    public enum ViewMode
    {
        Game = 0,
        Editor = 1
    }

    public enum WagonPartType
    {
        Visual = 0,
        C
    }

    public class WagonPart : MonoBehaviour
    {

    }

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
