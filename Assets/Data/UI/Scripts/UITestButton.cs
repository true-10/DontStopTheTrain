using DontStopTheTrain.Train;
using TMPro;
using UnityEngine;
using Zenject;

namespace DontStopTheTrain
{
    public class UITestButton : MonoBehaviour
    {
        [Inject]
        private WagonObjectsManager _wagonObjectsManager;


        [SerializeField]
        private TextMeshProUGUI _buttonText;
        [SerializeField]
        private SystemVisualUpdater _systemVisualUpdater;
        [SerializeField]
        private SystemViewModeSwitcher _systemVisualObject;

        private void Start()
        {
            _buttonText.text = "Апгрейд";
            _systemVisualUpdater.Initialize();
        }

        public void TestAction()
        {
            //_systemVisualUpdater.NextVisualModel();
            _systemVisualObject.SwitchToConstructorMode();
            return;
            var wagonObject = _wagonObjectsManager.SelectedWagonObject;
            if (wagonObject == null)
            {
                return;
            }
            if (wagonObject.TryGetComponent<WagonViewModeSwitcher>(out var switcher))
            {
                switcher.SwitchSystemsToConstructorMode();
            }

        }
    }

}
