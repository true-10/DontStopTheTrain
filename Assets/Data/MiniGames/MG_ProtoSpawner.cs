using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// universal spawner for mini games
/// </summary>
public class MG_ProtoSpawner : MonoBehaviour
{
    [SerializeField]
    private TSS_Bolid bulletPrefab;
    [SerializeField]
    private Transform bulletRoot;

    private List<GameObject> bullets = new();

    public void SpawnBullet(Vector3 pos, Quaternion rot)
    {
        var unit = Instantiate(bulletPrefab, pos, rot, bulletRoot);
        bullets.Add(unit.gameObject);
    }

    public void ClearBullets()
    {
        bullets.ForEach(x => Destroy(x.gameObject));
        bullets.Clear();
    }
}
