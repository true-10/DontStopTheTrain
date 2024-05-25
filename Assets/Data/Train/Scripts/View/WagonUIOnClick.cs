using DontStopTheTrain.UI;
using True10;
using UnityEngine;
using Zenject;

namespace DontStopTheTrain.Train
{
    public sealed class WagonUIOnClick : BaseClickableView
    {
        [Inject]
        private UIContainer _UIContainer;

        [SerializeField]
        private WagonObject _wagonObject;

        protected override void OnClickViewHandler()
        {
            var wagonUI = _UIContainer.GetUIScreen(UIScreenID.Wagon) as UIWagon;
            wagonUI?.Show(_clickableView);

            var gameplayUI = _UIContainer.GetUIScreen(UIScreenID.Gameplay);
            gameplayUI?.Hide();
            _UIContainer.WagonInfoPopup.Hide();
        }

        protected override void OnExitViewHandler()
        {
            var gameplayUI = _UIContainer.GetUIScreen(UIScreenID.Gameplay);
            gameplayUI?.Show();
        }

        protected override void OnMouseOverEnterHandler()
        {
            _UIContainer.WagonInfoPopup.Show(_wagonObject.WagonData, transform);
        }

        protected override void OnMouseOverExitHandler()
        {
            _UIContainer.WagonInfoPopup.Hide();
        }

    }
   
}
