using DontStopTheTrain.Train;
using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using True10.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace DontStopTheTrain.UI
{
    //UISystemUpgrader
    public class UIPartUpgrader : UIScreen, IGameLifeCycle
    {
        public override UIScreenID ScreenID => UIScreenID.PartUpgrader;

        [Inject]
        private SystemUpgrader _partUpgrader;
        [Inject]
        private WagonPartsStaticStorage _wagonPartsStaticStorage;

        [SerializeField]
        private Button _nextPartButton;
        [SerializeField]
        private Button _prevPartButton;
        [SerializeField]
        private Button _applyPartButton;
        [SerializeField]
        private Button _cancelButton;
        [SerializeField]
        private TextMeshProUGUI _descriptionText;
        [SerializeField]
        private Image _iconImage;

        private int _currentIndex = 0;
        private List<WagonSystemVisualData> _parts;


        public void Initialize()
        {
            _nextPartButton.onClick.AddListener(NextPartHandler);
            _prevPartButton.onClick.AddListener(PrevPartHandler);
            _applyPartButton.onClick.AddListener(ApplyHandler);
            _cancelButton.onClick.AddListener(CancelHandler);

            OnShow += OnShowHandler;
        }

        public void Dispose()
        {
            _nextPartButton.onClick.AddListener(NextPartHandler);
            _prevPartButton.onClick.AddListener(PrevPartHandler);
            _applyPartButton.onClick.AddListener(ApplyHandler);
            _cancelButton.onClick.AddListener(CancelHandler);
            
            OnShow -= OnShowHandler;
        }

        private void OnShowHandler(bool isShow)
        {
            if (isShow)
            {
                var partType = _partUpgrader.CurrentPartStatic.Type;
                _parts = _wagonPartsStaticStorage.Datas.Where(part => part.Type == partType).ToList();
            }
        }

        private void NextPartHandler()
        {
            if (IsPartsAvailable())
            {
                _currentIndex++;
                ShowCurrentPart();
            }
        }

        private void PrevPartHandler()
        {
            if (IsPartsAvailable())
            {
                _currentIndex--;
                ShowCurrentPart();
            }
        }

        private bool IsPartsAvailable()
        {
            if (_parts == null || _parts.Count < 2)
            {
                return false;
            }

            return true;
        }

        private void ShowCurrentPart()
        {
            _currentIndex = Clamp(_currentIndex, _parts.Count);
            var partStatic = _parts[_currentIndex];
            _partUpgrader.TryToReplace(partStatic);
        }

        private int Clamp(int index, int max)
        {
            if (index < 0)
            {
                return max - 1;
            }
            if (index > max - 1)
            {
                return 0;
            }
            return index;
        }

        private void ApplyHandler()
        {
            //TODO: сохраняем изменения

            _partUpgrader.SetCurrentSystemStatic(null);
            Hide();
        }

        private void CancelHandler()
        {
            _partUpgrader.Undo();
            _partUpgrader.SetCurrentSystemStatic(null);
            Hide();
        }

        private void Start()
        {
            Hide();
            Initialize();
        }

        private void OnDestroy()
        {
            Dispose();
        }
    }
}
