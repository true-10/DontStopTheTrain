using DontStopTheTrain.Events;
using TMPro;
using True10.UI;
using UnityEngine;

namespace DontStopTheTrain
{
    public class UIEventInfoPopup : UIScreen
    {
        [SerializeField]
        private TextMeshProUGUI _nameText;
        [SerializeField]
        private TextMeshProUGUI _descriptionText;
        [SerializeField]
        private TextMeshProUGUI _conditionText;
        [SerializeField]
        private SetWorldPosition _worldPostionSetter;

        public void Show(IEvent eventData, Transform lookAt)
        {
            _nameText.text = eventData.StaticData.Info.Name;
            _descriptionText.text = eventData.StaticData.Info.Description;
            _conditionText.text = ConditionToTextConverter.GetText(eventData.ÑompleteConditions, eventData.ActionPointPrice);
            _worldPostionSetter.SetPosition(lookAt);
            Show();

        }
        private void Start()
        {
            Hide();
        }
    }

}
