using DontStopTheTrain.Events;
using DontStopTheTrain.UI;
using System;
using TMPro;
using True10.DayTimeSystem;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using static System.Net.Mime.MediaTypeNames;

namespace DontStopTheTrain
{

    public class UIMainGamePlay : UIScreen
    {
        [Inject]
        private Player _player;
        [Inject]
        private TurnBasedController _turnBasedController;
        [Inject]
        private UIController _uiController;
        [Inject]
        private EventController _eventController;
        [Inject]
        private DayTimeSystem _dayTimeSystem;

        [SerializeField]
        private Button _completeButton;
        [SerializeField]
        private TextMeshProUGUI _turnNumberText;

        private CompositeDisposable _disposables = new CompositeDisposable();

        private void OnEnable()
        {
            _dayTimeSystem.OnChange += OnTimeChange;
            _completeButton.onClick.AddListener(CompleteTurn);
           // _player.Days.Subscribe(x => UpdateTurnText(x)).AddTo(_disposables);
            UpdateTurnText(_player.Days.Value);
        }

        private void OnDisable()
        {
            _dayTimeSystem.OnChange -= OnTimeChange;
            _completeButton.onClick.RemoveAllListeners();
            _disposables.Clear();
        }

        private void OnTimeChange(DateTime time)
        {
            _turnNumberText.text = $"Day: {time.Day} Time: {time.Hour}:{time.Minute}"; 
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
    }

}
