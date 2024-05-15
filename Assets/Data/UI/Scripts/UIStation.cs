using DontStopTheTrain.UI;
using System.Collections;
using System.Collections.Generic;
using True10.DayTimeSystem;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace DontStopTheTrain.UI
{

    public class UIStation : UIScreen
    {
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

        public void Depart()
        {
            _UIContainer.MainGamePlay.Show();
            _UIContainer.Station.Hide();
            var locomotive = _wagonsManager.GetLocomotive();

            _dayTimeSystem.UnPause();
            locomotive.StartMotion();
        }

        public void OpenShop()
        {

        }

        public void OpenQuestList()
        {
            //список грузов для следующей станции. если условия погрузки выполняются, то можно взять. (если есть место, например)
        }

        private void OnEnable()
        {
            _departButton.onClick.AddListener(Depart);
            _shopButton.onClick.AddListener(OpenShop);
            _questsButton.onClick.AddListener(OpenQuestList);
        }

        private void OnDisable()
        {
            _departButton.onClick.RemoveAllListeners();
            _shopButton.onClick.RemoveAllListeners();
            _questsButton.onClick.RemoveAllListeners();
        }
    }
}
