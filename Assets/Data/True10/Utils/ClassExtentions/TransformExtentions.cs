
using UnityEngine;

public static class TransformExtentions
{
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
