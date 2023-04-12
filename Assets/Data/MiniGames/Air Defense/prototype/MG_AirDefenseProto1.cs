using DontStopTheTrain.MiniGames;
using System.Collections;
using System.Collections.Generic;
using True10.CameraSystem;
using UnityEngine;
using Zenject;

public class MG_AirDefenseProto1 : MonoMiniGame
{
    [Inject] private ICameraController cameraController;

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
        cameraController.SwitchToCamera(turretCamera.HashCode);
    }

    public override void StopMiniGame()
    {
        enemySpawner.StopAndClear();
        defenseControls.Clear();
        defenseControls.SetActive(false);
        cameraController.SwitchToDefaultCamera();
    }
}
