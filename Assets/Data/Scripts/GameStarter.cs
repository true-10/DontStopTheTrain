using DontStopTheTrain.UI;
using True10.CameraSystem;
using True10.DayTimeSystem;
using UnityEngine;
using Zenject;


namespace DontStopTheTrain
{
    public class GameStarter : MonoBehaviour
    {
        [Inject]
        private UIContainer _UIContainer;
        [Inject]
        private ICameraController _cameraController;

        private void Start()
        {
            FadeOut();
            StartGame();
        }

        private void ShowStartMenu()
        {
            var screen = _UIContainer.GetUIScreen(UIScreenID.StartMenu);
            screen.Show();
        }

        private void StartGame()
        {
          /*  _turnBasedController.StartLoop();
            var locomotive = _wagonsManager.GetLocomotive();

            _dayTimeSystem.UnPause();
            locomotive.StartMotion();
            Hide();*/
            var gamePlayUI = _UIContainer.GetUIScreen(UIScreenID.Gameplay);
            gamePlayUI?.Show();
            _cameraController.SwitchToDefaultCamera();
           // _cameraHolder.SwitchToDefaultCamera();
        }

        private void FadeOut()
        {
            var fader = _UIContainer.GetUIScreen(UIScreenID.Fader) as UIFader;
            fader?.FadeOut(0f, () =>
            {
                Application.Quit();
            });
        }
    }
}
