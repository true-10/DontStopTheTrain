using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace True10.DebugUtils
{

    public class UIFPSCounter : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI fpsText;

        private int fpsCount = 0;
        private float timer = 0f;

        void Update()
        {
            fpsCount++;
            timer += Time.deltaTime;

            if (timer > 1f)
            {
                fpsText.text = $"fps: {fpsCount}";
                fpsCount = 0;
                timer = 0f;
            }
        }
    }

}
