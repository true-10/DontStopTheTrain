using UnityEngine;
using Zenject;
using DontStopTheTrain;

namespace True10.DayLightSystem
{
    public class DayNightSwitcher : MonoBehaviour
    {
        [Inject]
        private TurnBasedController _turnBasedController;

        [SerializeField]
        private DayNightController _dayNightController;
       // [SerializeField]
        //private List<DayNightSettings> _settings;
        [SerializeField]
        private DayNightSettings _morningSettings;
        [SerializeField]
        private DayNightSettings _daySettings;
        [SerializeField]
        private DayNightSettings _eveningSettings;
        [SerializeField]
        private DayNightSettings _nightSettings;

        private DayNightSettings _currentSetting;


        [ContextMenu("Apply Current Settings")]
        public void ApplyCurrentSettings()
        {
            _dayNightController.StartTransition(_currentSetting);
        }

        private void OnTurnEnd(ITurnCallback callback)
        {
            //переделать в список и подставлять как индекс
            var currentState = callback.Number % 4;
           
            switch (currentState) 
            {
                case 0:
                    _currentSetting = _morningSettings;
                    break;
                case 1:
                    _currentSetting = _daySettings;
                    break;
                case 2:
                    _currentSetting = _eveningSettings;
                    break;
                case 3:
                    _currentSetting = _nightSettings;
                    break;
            }
            //TODO: add sun rotation and color change
            _dayNightController.StartTransition(_currentSetting);
        }

        private void Start()
        {
            _currentSetting = _morningSettings;
            _turnBasedController.OnTurnEnd += OnTurnEnd;
            _dayNightController.Initialize(_currentSetting);
        }

        private void OnDestroy()
        {
            _turnBasedController.OnTurnEnd -= OnTurnEnd;
        }
    }
}
