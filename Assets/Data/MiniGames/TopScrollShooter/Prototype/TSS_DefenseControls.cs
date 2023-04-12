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
    private GameObject muzzleFlash;
    [SerializeField]
    private MG_ProtoSpawner protoSpawner;
    [SerializeField]
    private float cooldown = .5f;

    [SerializeField]
    private Transform startBulletPosition;
    [SerializeField]
    private Camera camera;

    private bool isEnabled = false;
    private float currentTime = 0;
    private float cooldownTime = 0;


    private void Update()
    {
        if (isEnabled == false)
        {
            return;
        }

        currentTime += Time.deltaTime;
        InputUpdate();
    }

    public void SetActive(bool isEnabled) => this.isEnabled = isEnabled;

    private void InputUpdate()
    {
        var isFire = Input.GetMouseButton(0);
        muzzleFlash.SetActive(isFire);
        if (isFire)
        {
            Fire();
        }

        LookAtMouseCursor();
    }

    private void Fire()
    {
        if (currentTime < cooldownTime)
        {
            return;
        }
        cooldownTime = currentTime + cooldown;
        var pos = startBulletPosition.transform.position;
        var rot = startBulletPosition.transform.rotation;

        protoSpawner.SpawnBullet(pos, rot);
    }

    public void Clear()
    {
        protoSpawner.ClearBullets();
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
