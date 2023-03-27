using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG_TopScrollShooterProto1 : MonoBehaviour
{
    [SerializeField]
    private TSS_EnemySpawner enemySpawner;
    [SerializeField]
    private 
    // Start is called before the first frame update
    void Start()
    {
        enemySpawner.StartSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
