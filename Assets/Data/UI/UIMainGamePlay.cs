using DontStopTheTrain.Events;
using DontStopTheTrain.UI;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

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

        [SerializeField]
        private Button _completeButton;
        [SerializeField]
        private TextMeshProUGUI _turnNumberText;

        ////////////TEST        
        public void StartTestEvent()
        {


        }
        ////////////endTest

        private CompositeDisposable _disposables = new CompositeDisposable();

        private void OnEnable()
        {
            _turnBasedController.OnTurnStart += OnTurnStarted;
            _turnBasedController.OnTurnEnd += OnTurnEnded;
            _completeButton.onClick.AddListener(CompleteTurn);
            _player.Days.Subscribe(x => UpdateTurnText(x)).AddTo(_disposables);
            UpdateTurnText(_player.Days.Value);
        }

        private void OnDisable()
        {
            _turnBasedController.OnTurnStart -= OnTurnStarted;
            _turnBasedController.OnTurnEnd -= OnTurnEnded;
            _completeButton.onClick.RemoveAllListeners();
            _disposables.Clear();
        }

        private void OnTurnEnded(ITurnCallback callback)
        {
            //Debug.Log($"Turn[{callback.Number}] is ended");
        }

        private void OnTurnStarted(ITurnCallback callback)
        {
            //Debug.Log($"Turn[{callback.Number}] is started");
            _turnBasedController.StartTurn();
        }

        private void CompleteTurn()
        {
            _turnBasedController.CompleteTurn();
        }

        private void UpdateTurnText(int turn)
        {
            var text = $"{turn}";
            _turnNumberText.text = text;
            //_uiController.Message.ShowMessage(text, 1f);
        }
    }

}
