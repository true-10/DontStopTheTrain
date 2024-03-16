using System;
using UnityEngine;

namespace DontStopTheTrain.Train
{
    public class InteriorShower : MonoBehaviour
    {
        [SerializeField]
        private WagonView _wagon;
        [SerializeField]
        private GameObject _frontWall;

        private void OnExitWagonView()
        {
            _frontWall.SetActive(true);
        }

        private void OnEnterWagonView()
        {
            _frontWall.SetActive(false);
        }

        private void OnEnable()
        {
            _wagon.OnEnter += OnEnterWagonView;
            _wagon.OnExit += OnExitWagonView;
        }

        private void OnDisable()
        {
            _wagon.OnEnter -= OnEnterWagonView;
            _wagon.OnExit -= OnExitWagonView;
        }
    }
}
