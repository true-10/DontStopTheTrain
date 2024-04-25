using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace True10.DebugUtils
{

    public class UIFPSCounter : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _fpsText;

        private int _fpsCount = 0;
        private float _timer = 0f;

        private void Update()
        {
            _fpsCount++;
            _timer += Time.deltaTime;

            if (_timer > 1f)
            {
                _fpsText.text = $"fps: {_fpsCount}";
                _fpsCount = 0;
                _timer = 0f;
            }
        }
    }

}
