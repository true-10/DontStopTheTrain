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
        private Button _fixButton;
        [SerializeField]
        private TextMeshProUGUI _wagonInfo;

        private WagonView _wagonView;

        public void Show(WagonView wagon)
        {
            _wagonView = wagon;
            Show();
        }

        private void OnCloseUI()
        {
            _wagonView.Exit();
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
