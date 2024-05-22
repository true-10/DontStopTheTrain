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

        private IWagon _wagonData;

        public override void Initialize()
        {
            base.Initialize();
            _wagonData ??= _wagonObject.WagonData;
        }

       /* public void SetWagonData(IWagon wagonData)
        {
            _wagonData ??= wagonData;
        }*/

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
            _UIContainer.WagonInfoPopup.Show(_wagonData, transform);
        }

        protected override void OnMouseOverExitHandler()
        {
            _UIContainer.WagonInfoPopup.Hide();
        }

    }
   
}
