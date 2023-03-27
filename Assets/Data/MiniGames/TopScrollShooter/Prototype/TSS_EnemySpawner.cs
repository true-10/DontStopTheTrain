using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

public class TSS_EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private Transform startPosition;
    [SerializeField]
    private Transform enemyRoot;
    [SerializeField]
    private TSS_Unit enemyPrefab;
    [SerializeField]
    private float spawnCooldownSec = 1f;
    [SerializeField]
    private int spawnCount = 10;
    [SerializeField]
    private float  spawnXRange = 50;

    private List<TSS_Unit> enemies = new List<TSS_Unit>();

    private IDisposable spawnInterval = null;

    
    public void StartSpawn()
    {
        if (spawnInterval == null)
        {
            spawnInterval = Observable.Interval(TimeSpan.FromSeconds(spawnCooldownSec))
                .Subscribe((x) => 
                { 
                    if (enemies.Count < spawnCount)
                    {
                        SpawnUnit();
                    }
                }).AddTo(this);
        }
    }

    private void SpawnUnit()
    {
        var unit = Instantiate(enemyPrefab, enemyRoot);
        var xRandomRange = UnityEngine.Random.Range(-spawnXRange, spawnXRange);
        var pos = startPosition.transform.position + Vector3.right * xRandomRange;
        unit.transform.position = pos;
        enemies.Add(unit);
        UpdateList();
    }

    private void UpdateList()
    {
        var newList = enemies
            .Where(x => x != null)
            .ToList();

        enemies = newList;
    }
}
