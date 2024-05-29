using UnityEngine;

namespace DontStopTheTrain.Train.Constructor
{
    public class WagonUpgradeView : BaseClickableView
    {
        [SerializeField]
        private GameObject _selectionObject;
        [SerializeField]
        private WagonViewModeSwitcher _wagonModeSwitcher;

        protected override void OnClickViewHandler()
        {
            _selectionObject?.SetActive(false);
            _wagonModeSwitcher.SwitchSystemsToConstructorMode();
            //var updateScreen = _UIContainer.GetUIScreen(UIScreenID.SystemUpgrader) as UISystemUpgrader;
            //updateScreen.SetVisualUpdater(_systemVisualUpdater);
            //updateScreen?.Show();
        }

        protected override void OnExitViewHandler()
        {
            _selectionObject?.SetActive(false);
            _wagonModeSwitcher.SwitchSystemsToGameMode();
        }

        protected override void OnMouseOverEnterHandler()
        {
            _selectionObject?.SetActive(true);
        }

        protected override void OnMouseOverExitHandler()
        {
            _selectionObject?.SetActive(false);
        }
    }
}
