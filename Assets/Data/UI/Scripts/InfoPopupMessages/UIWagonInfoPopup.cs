using DG.Tweening;
using DontStopTheTrain.Train;
using TMPro;
using True10.UI;
using UnityEngine;
using UnityEngine.UI;

namespace DontStopTheTrain.UI
{
    public class UIWagonInfoPopup : UIScreen
    {
        public override UIScreenID ScreenID => UIScreenID.None;

        [SerializeField]
        private Image _icon;
        [SerializeField]
        private TextMeshProUGUI _nameText;
        [SerializeField]
        private TextMeshProUGUI _descriptionText;
        [SerializeField]
        private Transform _hideTransform;
        [SerializeField]
        private Transform _showTransform;
        [SerializeField]
        private float _appearDuration = 1f;
        [SerializeField]
        private float _disappearDuration = 1f;

        private Transform _cachedTranform;
        private Tween _tween;

        public void Show(IWagon wagonData, Transform lookAt)
        {
            if (wagonData != null)
            {
                _nameText.text = wagonData.StaticData.Info.Name;
                _descriptionText.text = wagonData.StaticData.Info.Description;
                _icon.sprite = wagonData.StaticData.Info.Icon;
            }
            else
            {
                Debug.Log($"wagonData == null");
            }

            Show();
            _tween?.Kill();
            _tween = _cachedTranform.DOMove(_showTransform.position, _appearDuration);
        }

        public override void Hide()
        {
            _tween?.Kill();
            _tween = _cachedTranform
                .DOMove(_hideTransform.position, _disappearDuration)
                .OnComplete(() => { base.Hide(); });

            
        }

        private void Start()
        {
            _cachedTranform = _root.transform;
            Hide();
        }
    }

}
