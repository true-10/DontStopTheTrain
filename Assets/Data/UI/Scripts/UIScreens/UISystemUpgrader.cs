using DontStopTheTrain.Train;
using TMPro;
using True10.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace DontStopTheTrain.UI
{
    public class UISystemUpgrader : UIScreen, IGameLifeCycle
    {
        public override UIScreenID ScreenID => UIScreenID.SystemUpgrader;

        [Inject]
        private UIContainer _UIContainer;

        [SerializeField]
        private Button _nextPartButton;
        [SerializeField]
        private Button _prevPartButton;
        [SerializeField]
        private Button _applyPartButton;
        [SerializeField]
        private Button _cancelButton;
        [SerializeField]
        private TextMeshProUGUI _descriptionText;
        [SerializeField]
        private Image _iconImage;

        private SystemVisualUpdater _systemVisualUpdater;

        public void SetVisualUpdater(SystemVisualUpdater systemVisualUpdater)
        {
            _systemVisualUpdater = systemVisualUpdater;
            _systemVisualUpdater.Initialize();
        }

        public void Initialize()
        {
            _nextPartButton.onClick.AddListener(NextPartHandler);
            _prevPartButton.onClick.AddListener(PrevPartHandler);
            _applyPartButton.onClick.AddListener(ApplyHandler);
            _cancelButton.onClick.AddListener(CancelHandler);

            OnShow += OnShowHandler;
        }

        public void Dispose()
        {
            _nextPartButton.onClick.AddListener(NextPartHandler);
            _prevPartButton.onClick.AddListener(PrevPartHandler);
            _applyPartButton.onClick.AddListener(ApplyHandler);
            _cancelButton.onClick.AddListener(CancelHandler);
            
            OnShow -= OnShowHandler;
        }

        private void OnShowHandler(bool isShow)
        {

        }

        private void NextPartHandler()
        {
            _systemVisualUpdater?.NextVisualModel();
        }

        private void PrevPartHandler()
        {
            _systemVisualUpdater?.PrevVisualModel();
        }

        private void ApplyHandler()
        {
            _systemVisualUpdater?.CommitUpdate();
            _systemVisualUpdater = null;
            Hide();

            var screen = _UIContainer.GetUIScreen(UIScreenID.Constructor);
            screen?.Show();
        }

        private void CancelHandler()
        {
            _systemVisualUpdater?.Undo();
            _systemVisualUpdater = null;
            Hide();
            var screen = _UIContainer.GetUIScreen(UIScreenID.Constructor);
            screen?.Show();
        }

        private void Start()
        {
            Hide();
            Initialize();
        }

        private void OnDestroy()
        {
            Dispose();
        }
    }
}
