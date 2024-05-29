using DontStopTheTrain.UI;
using UnityEngine;
using Zenject;

namespace DontStopTheTrain.Train.Constructor
{
    public class SystemUpgradeView : BaseClickableView
    {
       // public IWagonSystemVisualData StaticData => _systemObject.WagonSystem.StaticData.VisualData;

        [Inject]
        private UIContainer _UIContainer;

        //[SerializeField]
        //private WagonSystemObject _systemObject;
        [SerializeField]
        private SystemVisualUpdater _systemVisualUpdater;
        [SerializeField]
        private GameObject _selectionObject;

        public override void Dispose()
        {
            base.Dispose();
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void OnClickViewHandler()
        {
            _selectionObject?.SetActive(false);
            var updateScreen = _UIContainer.GetUIScreen(UIScreenID.SystemUpgrader) as UISystemUpgrader;
            updateScreen.SetVisualUpdater(_systemVisualUpdater);
            updateScreen?.Show();
        }

        protected override void OnExitViewHandler()
        {
            _selectionObject?.SetActive(false);
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
