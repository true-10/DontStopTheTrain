using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DontStopTheTrain.UI
{
    public class UIPartUpgrader : UIScreen
    {
        [SerializeField]
        private Button _nextPart;
        [SerializeField]
        private Button _prevPart;
        [SerializeField]
        private TextMeshProUGUI _descriptionText;
        [SerializeField]
        private Image _iconImage;

    }
}
