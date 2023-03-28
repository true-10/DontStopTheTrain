using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TSS_DefenseControls : MonoBehaviour
{
    [SerializeField]
    private Transform turretTransform;
    [SerializeField]
    private float rotationSpeed = 30f;

    [SerializeField]
    private Transform bulletPrefab;

    [SerializeField]
    private Transform startBulletPosition;
    [SerializeField]
    private Transform bulletRoot;
    [SerializeField]
    private Camera camera;


    private void Update()
    {
        InputUpdate();
    }

    private void Fire()
    {
        var pos = startBulletPosition.transform.position;
        var rot = startBulletPosition.transform.rotation;
        var unit = Instantiate(bulletPrefab, pos, rot, bulletRoot);
    }

    private void InputUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            Fire();
        }

        LookAtMouseCursor();

       
    }

    public void LookAtMouseCursor()
    {
        var mousePos = Vector3.zero;
        mousePos = Input.mousePosition;
        var ray = camera.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 200f) )//, 1 << LayerMask.NameToLayer("Ground")))
        {
            Vector3 point = hit.point;
            point.y = turretTransform.position.y;
            var lookDir = point - turretTransform.position;
            turretTransform.rotation = Quaternion.LookRotation(lookDir);
           // turretTransform.rotation = Quaternion.Lerp(turretTransform.rotation,
             //   Quaternion.LookRotation(lookDir.normalized), rotationSpeed * Time.deltaTime);
        }
    }

}
