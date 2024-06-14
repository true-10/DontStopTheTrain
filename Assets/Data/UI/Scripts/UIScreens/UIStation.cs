using True10.DayTimeSystem;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace DontStopTheTrain.UI
{
    public class UIStation : UIScreen
    {
        public override UIScreenID ScreenID => UIScreenID.Station;

        [Inject]
        private DayTimeSystem _dayTimeSystem;
        [Inject]
        private WagonsManager _wagonsManager;
        [Inject]
        private UIContainer _UIContainer;

        [SerializeField]
        private Button _departButton;
        [SerializeField]
        private Button _shopButton;
        [SerializeField]
        private Button _questsButton;
        [SerializeField]
        private Button _upgradesButton;

        public void Depart()
        {
            var gamePlayUI = _UIContainer.GetUIScreen(UIScreenID.Gameplay);
            gamePlayUI?.Show();
            var stationUI = _UIContainer.GetUIScreen(UIScreenID.Station);
            stationUI?.Hide();
            var locomotive = _wagonsManager.GetLocomotive();

            _dayTimeSystem.UnPause();
            locomotive.StartMotion();
        }

        public void OpenShop()
        {

        }

        public void OpenQuestList()
        {
            //������ ������ ��� ��������� �������. ���� ������� �������� �����������, �� ����� �����. (���� ���� �����, ��������)
        }

        public void OpenUpgradeScreen()
        {
            Hide();
            //� �������� ����� ������������ (������ ������ ������ �� ������ ������������)
            var upgradeScreen = _UIContainer.GetUIScreen(UIScreenID.Constructor);
            upgradeScreen?.Show();
        }

        private void OnEnable()
        {
            _departButton.onClick.AddListener(Depart);
            _shopButton.onClick.AddListener(OpenShop);
            _questsButton.onClick.AddListener(OpenQuestList);
            _upgradesButton.onClick.AddListener(OpenUpgradeScreen);
        }

        private void OnDisable()
        {
            _departButton.onClick.RemoveAllListeners();
            _shopButton.onClick.RemoveAllListeners();
            _questsButton.onClick.RemoveAllListeners();
            _upgradesButton.onClick.RemoveAllListeners();
        }

        private void Start()
        {
            Hide();
        }
    }
}
