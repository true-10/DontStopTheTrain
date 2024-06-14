using DontStopTheTrain.Train;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace DontStopTheTrain
{
    public class UITestButton : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _buttonText;

        private bool _isScaled = false;
        private void Start()
        {
            _buttonText.text = "таймскейл";
        }

        public void TestAction()
        {
            _isScaled = !_isScaled;
            if (_isScaled)
            {
                Time.timeScale = 1f;
            }
            else
            {
                Time.timeScale = 10f;
            }

            _buttonText.text = $"таймскейл {Time.timeScale}x";

        }
    }

}
