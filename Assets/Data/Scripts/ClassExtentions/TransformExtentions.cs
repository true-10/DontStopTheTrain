namespace True10.Extentions
{
    using UnityEngine;
    using System.Collections.Generic;

    public static class TransformExtentions
    {

        public static IEnumerable<Transform> Children(this Transform parent)
        {
            foreach (Transform child in parent)
            {
                yield return child;
            }
        }

        public static void PerformActhionOnChldre(this Transform parent, System.Action<Transform> action)
        {
            for (int i = parent.childCount; i >= 0; i--)
            {
                action?.Invoke(parent.GetChild(i));
            }

        }

        public static void DestroyChildren(this Transform parent)
        {
            parent.PerformActhionOnChldre(child => Object.Destroy(child));
        }

        public static void EnableChildren(this Transform parent)
        {
            parent.PerformActhionOnChldre(child => child.gameObject.SetActive(true));
        }

        public static void DisableChildren(this Transform parent)
        {
            parent.PerformActhionOnChldre(child => child.gameObject.SetActive(false));
        }


        private static void AlignTo(this Transform target, Transform pointToAlign)
        {
            if (pointToAlign == null)
            {
                Debug.Log("TransformExtentions: Alignment error: pointToAlign == null");
                return;
            }
            target.rotation = pointToAlign.rotation;
            target.position = pointToAlign.position;

            target.position += Quaternion.AngleAxis(pointToAlign.rotation.eulerAngles.y, Vector3.up) * -pointToAlign.localPosition;//-endPoint.localPosition;
        }
    }
}
