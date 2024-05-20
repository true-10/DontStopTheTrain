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
    //    [SerializeField]
      //  private TextMeshProUGUI _conditionText;
        [SerializeField]
        private SetWorldPosition _worldPostionSetter;
      // [SerializeField]
       // private Slider _healthSlider;

        public void AnchorIt()
        {

        }

        public void Show(IWagon wagonData, Transform lookAt)
        {
            _nameText.text = wagonData.StaticData.Info.Name;
            _descriptionText.text = wagonData.StaticData.Info.Description;
            _icon.sprite = wagonData.StaticData.Info.Icon;
           // _healthSlider.value = (float)wagonData.Health.Value / wagonData.MaxHealth.Value;

        //_conditionText.text = ConditionToTextConverter.GetText(wagonData.СompleteConditions, wagonData.ActionPointPrice);
            _worldPostionSetter.SetPosition(lookAt);
            Show();
        }

        private void Start()
        {
            Hide();
        }
    }

}
