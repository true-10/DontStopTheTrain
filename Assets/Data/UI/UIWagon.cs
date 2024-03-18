using DontStopTheTrain.Train;
using TMPro;
using True10;
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

        private ClickableView _clickableView;

        public void Show(ClickableView view)
        {
            _clickableView = view;
            Show();
        }

        private void OnCloseUI()
        {
            _clickableView.ExitView();
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
