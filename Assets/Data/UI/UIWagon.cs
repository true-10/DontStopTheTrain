using DontStopTheTrain.Train;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DontStopTheTrain
{ 
    public class UIWagon : UIScreen
    {
        [SerializeField]
        private Button _closeButton;
        [SerializeField]
        private TextMeshProUGUI _wagonInfo;

        private Wagon _wagon;

        public void Show(Wagon wagon)
        {
            _wagon = wagon;
            Show();
        }

        private void OnCloseUI()
        {
            _wagon.Exit();
          //  _wagon = null;
            Hide();
        }

        private void Start()
        {
            Hide();
        }

        private void OnEnable()
        {
            _closeButton.onClick.AddListener(OnCloseUI);
        }

        private void OnDisable()
        {
            _closeButton.onClick.RemoveAllListeners();
        }
    }
}
