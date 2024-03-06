using DontStopTheTrain.Events;
using DontStopTheTrain.UI;
using System.Linq;
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
        [Inject]
        private UIController _uiController;
        [Inject]
        private EventController _eventController;


        [SerializeField]
        private GameObject _root;
        [SerializeField]
        private Button _completeButton;
        [SerializeField]
        private TextMeshProUGUI _turnNumberText;

        ////////////TEST
        /* [SerializeField]
         private EventId _startEventTestId;
         [Inject]
         private EventFabric _eventFabric;
         [Inject]
         private EventsStaticManager _eventsStaticManager;*/
        public void StartTestEvent()
        {
          /*  var eventStatic = _eventsStaticManager.EventsStaticData.FirstOrDefault(ev => ev.Id == _startEventTestId);
            var eventData = _eventFabric.CreateEvent(eventStatic);
            _eventController.StartEvent(eventData);
            _uiController.WagonEvent.Show(eventData);
           // _eventController.OnComplete += _ => Show(true);
            Show(false);*/

        }
        ////////////endTest

        private CompositeDisposable _disposables = new CompositeDisposable();

        public void Show(bool isActive)
        {
            _root.SetActive(isActive);
        }

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
            Debug.Log($"CompleteTurn");
            _turnBasedController.CompleteTurn();
        }

        private void UpdateTurnText(int turn)
        {
            var text = $"{turn}";
            _turnNumberText.text = text;
            _uiController.Message.ShowMessage(text, 1f);
        }
    }

}
