using DontStopTheTrain.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace DontStopTheTrain.UI
{
    //BaseEventUIView
    public class StationEventUIView : MonoBehaviour
    {
        [SerializeField]
        private Button departButton; 

        public Action OnDepartButtonClick { get; set; }

        private void Start()
        {
            departButton.onClick.AddListener(OnDepartButtonClickHandler);
        }

        private void OnDepartButtonClickHandler()
        {
            OnDepartButtonClick?.Invoke();
        }
    }

}
