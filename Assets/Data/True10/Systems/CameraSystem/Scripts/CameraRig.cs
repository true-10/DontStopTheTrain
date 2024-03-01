using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRig : MonoBehaviour
{
    [SerializeField] private Transform root;
    [SerializeField] private Transform follow;
    [SerializeField] private Transform lookAt;

    public Transform Root => root;
    public Transform Follow => follow;
    public Transform LookAt => lookAt;

}
