using DontStopTheTrain;
using DontStopTheTrain.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using True10.CameraSystem;
using True10.Extentions;
using UnityEngine;
using Zenject;

public class CameraSwitcherOnStartTurn : MonoBehaviour
{
    public enum SwitchMode
    {
        Line = 0,
        Random = 1,
        Weighted = 2,
    }

    [Inject]
    private TurnBasedController _turnBasedController;
    [SerializeField]
    private SwitchMode _switchMode = SwitchMode.Line;
    [SerializeField]
    private List<CameraHolder> _cameras;

    private CameraHolder _currentCamera;

    public void Initialize()
    {
        _currentCamera = GetNextCamera();
        _currentCamera.TurnOn();
        _turnBasedController.OnTurnStart += OnTurnStart;
    }

    public void Dispose()
    {
        _turnBasedController.OnTurnStart -= OnTurnStart;
    }
    private CameraHolder GetRandomWeightedCamera()
    {
        _cameras = _cameras
            .OrderByDescending(holder => holder.Weight)
            .ToList();

        int total = _cameras.Sum(holder => holder.Weight);

        int randomPoint = UnityEngine.Random.Range(0, total);
        var overallWeight = 0;

        for (int i = 0; i < _cameras.Count; i++)
        {
            var chance = _cameras[i].Weight;
            overallWeight += chance;
            if (overallWeight >= randomPoint)
            {
                return _cameras[i];
            }
        }
        return null;
    }

    private CameraHolder GetNextCamera()
    {
        switch (_switchMode)
        {
            case SwitchMode.Random:
                return _cameras.GetRandomElement();
            case SwitchMode.Weighted:
                return GetRandomWeightedCamera();
            case SwitchMode.Line:
                { 
                    if (_currentCamera == null)
                    {
                        return _cameras.FirstOrDefault();
                    }
                    var index = _cameras.IndexOf(_currentCamera);
                    index++;
                    if (index > _cameras.Count - 1)
                    {
                        index = 0;
                    }
                    return _cameras[index];
                }
        }
        return GetRandomWeightedCamera();
    }

    private void OnTurnStart(ITurnCallback callback)
    {
        _currentCamera = GetNextCamera();
        _currentCamera.TurnOn();
    }

    private void Start()
    {
        Initialize();
    }

    private void OnDestroy()
    {
        Dispose();
    }
}
