using DontStopTheTrain.MiniGames;
using System.Collections;
using System.Collections.Generic;
using True10.CameraSystem;
using UnityEngine;
using Zenject;

public class MG_Disassembly_proto1 : MonoMiniGame
{
    [Inject] private ICameraController cameraController;

    [SerializeField]
    private CameraHolder camera;

    public override void StartMiniGame()
    {
        cameraController.SwitchToCamera(camera.HashCode);
    }

    public override void StopMiniGame()
    {
        cameraController.SwitchToDefaultCamera();
    }
}
