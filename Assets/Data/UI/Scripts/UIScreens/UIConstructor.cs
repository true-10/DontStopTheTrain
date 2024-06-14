using DontStopTheTrain.Train;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace DontStopTheTrain.UI
{
    public class UIConstructor : UIScreen
    {
        public override UIScreenID ScreenID => UIScreenID.Constructor;

        [Inject]
        private WagonObjectsManager _wagonObjectsManager;
        [Inject]
        private UIContainer _UIContainer;

        [SerializeField]
        private Button _exitButton;
        public override void Show()
        {
            base.Show();
            SwitchWagonToConstructorMode();
        }

        private void Exit()
        {
            Hide();
            SwitchWagonToGameMode();
            var screen = _UIContainer.GetUIScreen(UIScreenID.Station);
            screen?.Show();
        }

        private void SwitchWagonToConstructorMode()
        {

            //переключаем вагон в режим конструктора
            foreach (var wagonObject in _wagonObjectsManager.Items)
            {
                if (wagonObject.TryGetComponent<WagonViewModeSwitcher>(out var wagonViewModeSwitcher))
                {
                    wagonViewModeSwitcher.SwitchWagonToConstructorMode();
                }
            }
        }
        private void SwitchWagonToGameMode()
        {

            //переключаем вагон в режим конструктора
            foreach (var wagonObject in _wagonObjectsManager.Items)
            {
                if (wagonObject.TryGetComponent<WagonViewModeSwitcher>(out var wagonViewModeSwitcher))
                {
                    wagonViewModeSwitcher.SwitchWagonToGameMode();
                }
            }
        }


        private void OnEnable()
        {
            _exitButton.onClick.AddListener(Exit);
        }


        private void OnDisable()
        {
            _exitButton.onClick.RemoveAllListeners();
        }

        private void Start()
        {
            Hide();
        }
    }
}
