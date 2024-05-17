using DontStopTheTrain;
using True10.CameraSystem;
using True10.DayTimeSystem;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace DontStopTheTrain.UI
{

    public class UIStartMenu : UIScreen
    {
        [Inject]
        private DayTimeSystem _dayTimeSystem;
        [Inject]
        private WagonsManager _wagonsManager;
        [Inject]
        private UIContainer _UIContainer;
        [Inject]
        private TurnBasedController _turnBasedController;

        [SerializeField]
        private Button _startGameButton;
        [SerializeField]
        private Button _quitGameButton;
        [SerializeField]
        private CameraHolder _cameraHolder;


        private void StartGame()
        {
            _turnBasedController.StartLoop();
            var locomotive = _wagonsManager.GetLocomotive();

            _dayTimeSystem.UnPause();
            locomotive.StartMotion();
            Hide();
            var gamePlayUI = _UIContainer.GetUIScreen(UIScreenID.Gameplay);
            gamePlayUI?.Show();
            //_UIContainer.MainGamePlay.Show();
            _cameraHolder.SwitchToDefaultCamera();
        }

        private void QuitGame()
        {
            var fader = _UIContainer.GetUIScreen(UIScreenID.Fader) as UIFader;
            fader?.FadeIn(0f, () =>
            {
#if UNITY_EDITOR
                EditorApplication.ExitPlaymode();
#else
                Application.Quit();
#endif
            });
        }

      /*  private void Start()
        {
            Show();
        }
      */
        public override void Show()
        {
            base.Show();
            _dayTimeSystem.Pause();
            _cameraHolder.SwitchToThisCamera();
        }
        private void OnEnable()
        {
           // _dayTimeSystem.OnChange += OnTimeChange;
            _startGameButton.onClick.AddListener(StartGame);
            _quitGameButton.onClick.AddListener(QuitGame);

            
           // _dayTimeSystem.OnRewind += OnRewind;
        }

        private void OnDisable()
        {
            //_dayTimeSystem.OnChange -= OnTimeChange;
            _startGameButton.onClick.RemoveAllListeners();
            _quitGameButton.onClick.RemoveAllListeners();
            //_disposables.Clear();
            //_dayTimeSystem.OnRewind -= OnRewind;
        }
    }
}
