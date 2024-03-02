using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace DontStopTheTrain
{
    public class UIMainGamePlay : MonoBehaviour
    {
        [Inject]
        private Player _player;
        [Inject]
        private TurnBasedController _turnBasedController;

        [SerializeField]
        private Button _completeButton;
        [SerializeField]
        private TextMeshProUGUI _turnNumberText;

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
            Debug.Log($"Turn[{callback.Number}] is ended");
        }

        private void OnTurnStarted(ITurnCallback callback)
        {
            Debug.Log($"Turn[{callback.Number}] is started");
            _turnBasedController.StartTurn();
        }

        private void CompleteTurn()
        {
            Debug.Log($"CompleteTurn");
            _turnBasedController.CompleteTurn();
        }

        private void UpdateTurnText(int turn)
        {
            _turnNumberText.text = $"{turn}";
        }
    }

}
