using System;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace DontStopTheTrain
{
    public class UIPlayerInfo : MonoBehaviour
    {
        [Inject]
        private Player player;

        [SerializeField]
        private TextMeshProUGUI _actionPointText;
        [SerializeField]
        private TextMeshProUGUI _levelText;
        [SerializeField]
        private TextMeshProUGUI _expoText;
        [SerializeField]
        private TextMeshProUGUI _creditsText;
        private CompositeDisposable _disposables = new();

        private void Start()
        {
            player.ActionPoints.Subscribe(x => UpdateActionPointsText(x)).AddTo(_disposables);
            player.Level.Subscribe(x => UpdateLevelText(x)).AddTo(_disposables);
            player.Expo.Subscribe(x => UpdateExpText(x)).AddTo(_disposables);
            player.Credits.Subscribe(x => UpdateCreditsText(x)).AddTo(_disposables);

            UpdateActionPointsText(player.ActionPoints.Value);
            UpdateLevelText(player.Level.Value);
            UpdateExpText(player.Expo.Value);
            UpdateCreditsText(player.Credits.Value);
        }

        private void OnDestroy()
        {
            _disposables.Clear();
        }

        private void UpdateActionPointsText(int amount)
        {
            _actionPointText.text = $"ActionPoints: {amount}";
        }

        private void UpdateLevelText(int amount)
        {
            _levelText.text = $"Level: {amount}";
        }

        private void UpdateCreditsText(int amount)
        {
            _creditsText.text = $"Credits: {amount}";
        }

        private void UpdateExpText(int amount)
        {
            _expoText.text = $"Exp: {amount}";
        }

    }
}
