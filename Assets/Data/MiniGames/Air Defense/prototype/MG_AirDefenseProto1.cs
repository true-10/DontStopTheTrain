using DontStopTheTrain.MiniGames;
using System.Collections;
using System.Collections.Generic;
using True10.CameraSystem;
using UnityEngine;
using Zenject;

public class MG_AirDefenseProto1 : MonoMiniGame
{
    [SerializeField]
    private TSS_EnemySpawner enemySpawner;
    [SerializeField]
    private MG_AD_TurretControls defenseControls;
    [SerializeField]
    private CameraHolder turretCamera;

    public override void StartMiniGame()
    {
        enemySpawner.StartSpawn();
        defenseControls.SetActive(true);
        turretCamera.SwitchToThisCamera();
    }

    public override void StopMiniGame()
    {
        enemySpawner.StopAndClear();
        defenseControls.Clear();
        defenseControls.SetActive(false);
        turretCamera.SwitchToDefaultCamera();
    }
}
