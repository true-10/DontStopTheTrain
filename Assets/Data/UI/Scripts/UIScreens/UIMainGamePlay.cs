using DontStopTheTrain.Events;
using System;
using TMPro;
using True10.DayTimeSystem;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace DontStopTheTrain.UI
{
    public class UIMainGamePlay : UIScreen
    {
        [Inject]
        private Player _player;
        [Inject]
        private TurnBasedController _turnBasedController;
        [Inject]
        private UIContainer _UIContainer;
        [Inject]
        private EventController _eventController;
        [Inject]
        private DayTimeSystem _dayTimeSystem;

        [SerializeField]
        private Button _completeButton;
        [SerializeField]
        private Button _gameMenuButton;
        [SerializeField]
        private TextMeshProUGUI _turnNumberText;

        private CompositeDisposable _disposables = new CompositeDisposable();

        private void OnEnable()
        {
            _dayTimeSystem.OnChange += OnTimeChange;
            _completeButton.onClick.AddListener(CompleteTurn);
            _gameMenuButton.onClick.AddListener(ShowGameMenu);
           // _player.Days.Subscribe(x => UpdateTurnText(x)).AddTo(_disposables);
            UpdateTurnText(_player.Days.Value);
            _dayTimeSystem.OnRewind += OnRewind;
        }


        private void OnDisable()
        {
            _dayTimeSystem.OnChange -= OnTimeChange;
            _completeButton.onClick.RemoveAllListeners();
            _gameMenuButton.onClick.RemoveAllListeners();
            _disposables.Clear();
            _dayTimeSystem.OnRewind -= OnRewind;
        }

        private void ShowGameMenu()
        {
            Hide();
            var gameMenuUI = _UIContainer.GetUIScreen(UIScreenID.GameMenu);
            gameMenuUI?.Show();
        }

        private void OnRewind(bool isOnRewind)
        {
            _completeButton.gameObject.SetActive(isOnRewind == false);
        }

        private void OnTimeChange(DateTime time)
        {
            _turnNumberText.text = $"Day: {_player.Days} Time: {time.ToShortTimeString()}";
        }

        private void CompleteTurn()
        {
            _dayTimeSystem.RewindToNextDay();
        }

        private void UpdateTurnText(int turn)
        {
            var text = $"Day: {turn}";
            _turnNumberText.text = text;
            //_uiController.Message.ShowMessage(text, 1f);
        }

        private void Start()
        {
            Hide();
        }
    }

}
