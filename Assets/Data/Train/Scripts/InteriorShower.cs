using System;
using True10;
using UnityEngine;

namespace DontStopTheTrain.Train
{
    public class InteriorShower : MonoBehaviour
    {
        [SerializeField]
        private ClickableView _clickableView;
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
            _clickableView.OnClick += OnEnterWagonView;
            _clickableView.OnExitView += OnExitWagonView;
        }

        private void OnDisable()
        {
            _clickableView.OnClick -= OnEnterWagonView;
            _clickableView.OnExitView -= OnExitWagonView;
        }
    }
}
