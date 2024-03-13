using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DontStopTheTrain
{
    public class UIPerkElement : MonoBehaviour
    {
        public Action<IPerk> OnClick { get; set; }

        [SerializeField]
        private Button _selectionButton;
        [SerializeField]
        private Image _perkImage;
        [SerializeField]
        private GameObject _selectionImage;
        
        private IPerk _perk;

        public void Initialize(IPerk perk)
        {
            _perk = perk;
            _perkImage.sprite = perk.StaticData.Info.Icon;
        }

        public void Select(bool isActive)
        {
            _selectionImage.SetActive(isActive);
        }

        private void OnClickHandler()
        {
            OnClick?.Invoke(_perk);
            Select(true);
        }

        private void OnEnable()
        {
            _selectionButton.onClick.AddListener(OnClickHandler);
        }

        private void OnDisable()
        {
            Select(false);
            _selectionButton.onClick.RemoveAllListeners();
        }
    }
    
}
