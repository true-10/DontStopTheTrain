using True10.DayTimeSystem;
using True10.LevelScrollSystem;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace DontStopTheTrain.UI
{
    public class UIGameMenu : UIScreen
    {
        [Inject]
        private DayTimeSystem _dayTimeSystem;
        [Inject]
        private WagonsManager _wagonsManager;
        [Inject]
        private LevelScroller _levelScroller;
        [Inject]
        private UIContainer _UIContainer;

        [SerializeField]
        private Button _resumeGameButton;
        [SerializeField]
        private Button _quitGameButton;

        private float _speed;

        public override void Show()
        {
            base.Show();
            _speed = _levelScroller.ScrollSpeed;
            _dayTimeSystem.Pause();
        }

        private void ResumeGame()
        {
            _dayTimeSystem.UnPause();
            if (_speed != 0f)
            {
                var locomotive = _wagonsManager.GetLocomotive();
                locomotive.SetSpeed(_speed, 0f);
            }
            Hide();
            var gameplayUI = _UIContainer.GetUIScreen(UIScreenID.Gameplay);
            gameplayUI?.Show();
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

        private void Start()
        {
            Hide();
        }

        private void OnEnable()
        {
            _resumeGameButton.onClick.AddListener(ResumeGame);
            _quitGameButton.onClick.AddListener(QuitGame);
        }

        private void OnDisable()
        {
            _resumeGameButton.onClick.RemoveAllListeners();
            _quitGameButton.onClick.RemoveAllListeners();
        }
    }
}
