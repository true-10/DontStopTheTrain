using DontStopTheTrain.MiniGames;
using System.Collections;
using System.Collections.Generic;
using True10.CameraSystem;
using UnityEngine;
using Zenject;

public class MG_Disassembly_proto1 : MonoMiniGame
{
    [SerializeField]
    private CameraHolder cameraHolder;

    public override void StartMiniGame()
    {
        cameraHolder.SwitchToThisCamera();
    }

    public override void StopMiniGame()
    {
        cameraHolder.SwitchToDefaultCamera();
    }
}
