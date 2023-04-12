using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MG_AD_TurretControls : MonoBehaviour
{
    [SerializeField]
    private LocalTransformXRotator turretTransformXRotator;
    [SerializeField]
    private LocalTransformRotator turretTransformYRotator;
    [SerializeField]
    private float rotationSpeed = 30f;

    [SerializeField]
    private List<GameObject> muzzleFlashs;
    [SerializeField]
    private List<MG_ProtoSpawner> protoSpawners;
    [SerializeField]
    private float cooldown = .5f;

    [SerializeField]
    private Camera camera;

    public void SetActive(bool isEnabled) => this.isEnabled = isEnabled;

    private bool isEnabled = false;
    private float currentTime = 0;
    private float cooldownTime = 0;
    List<MG_ProtoSpawner> spawners1;
    List<MG_ProtoSpawner> spawners2;

    private void Start()
    {
        InitSpawners();
    }

    private void Update()
    {
        if (isEnabled == false)
        {
            return;
        }

        currentTime += Time.deltaTime;
        InputUpdate();
    }

    private void InitSpawners()
    {
        spawners1 = new();
        spawners2 = new();
        for (int i = 0; i < protoSpawners.Count; i++)
        {
            if (i % 2 == 0)
            {
                spawners1.Add(protoSpawners[i]);
            }else
            {
                spawners2.Add(protoSpawners[i]);
            }
        }
    }

    private void InputUpdate()
    {
        var isFire = Input.GetMouseButton(0);
        if (isFire)
        {
            Fire();
        }

        RotationInput();
    }

  //  private Vector3 prevPosition = Vector3.zero;

    private void RotationInput()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        //var inputPosition = Input.mousePosition;

        // var deltaX = inputPosition.x - prevPosition.x;
        //var deltaY = inputPosition.y - prevPosition.y;
        turretTransformXRotator.RotateAroundX(-mouseY);
        turretTransformYRotator.RotateAround(mouseX);

     //   prevPosition = inputPosition;
    }

    bool isSpawners1 = true;
    private void Fire()
    {
        if (currentTime < cooldownTime)
        {
            return;
        }
        cooldownTime = currentTime + cooldown;

        isSpawners1 = !isSpawners1;
        var spawners = spawners1;
        if (isSpawners1 == false)
        {
            spawners = spawners2;
        }

        for (int i = 0; i < spawners.Count; i++)
        {
            var protoSpawner = spawners[i];
            var pos = protoSpawner.transform.position;
            var rot = protoSpawner.transform.rotation;
            protoSpawner.SpawnBullet(pos, rot);
            // muzzleFlash.SetActive(isFire);
        }
        //стрел€ют через 1 все
    }

    public void Clear()
    {
        foreach (var protoSpawner in protoSpawners)
        {
            protoSpawner.ClearBullets();
        }
    }

}
