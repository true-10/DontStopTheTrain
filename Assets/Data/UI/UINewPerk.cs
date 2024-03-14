using System;
using TMPro;
using True10.Extentions;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace DontStopTheTrain
{
    public partial class UINewPerk : UIScreen
    {
        [Inject]
        private Player _player;
        [Inject]
        private PerksManager _perksManager;
        [Inject]
        private PerksLeveslStaticData _perksLeveslStaticData;

        [SerializeField]
        private UIPerkElement _perkElement1;
        [SerializeField]
        private UIPerkElement _perkElement2;
        [SerializeField]
        private Button _closeButton;
        [SerializeField]
        private TextMeshProUGUI _perkName;
        [SerializeField]
        private TextMeshProUGUI _perkDescription;

        private CompositeDisposable _disposables = new();
        private IPerk _currentPerk = null;

        private void OnLevelUp(int level)
        {
            //TODO: выдавать по уровню из статики. типа на 3, 5, 10 уровнях и тд
            if (_perksLeveslStaticData.Levels.Contains(level) == false)
            {
            //    return;
            }
            var perk1 = _perksManager.Items.GetRandomElement();
            var perk2 = _perksManager.Items.GetRandomElement();

            if (perk1 == null || perk2 == null)
            {
                return;
            }
            _currentPerk = perk1;

            _perkElement1.Initialize(perk1);
            _perkElement2.Initialize(perk2);
            UpdateInfo(_currentPerk);
            Show();
            _perkElement1.Select(true);
        }

        private void OnElementClick(IPerk perk)
        {
            _currentPerk = perk;
            _perkElement1.Select(false);
            _perkElement2.Select(false);
            UpdateInfo(_currentPerk);
        }

        private void UpdateInfo(IPerk perk)
        {
            _perkName.text = perk.StaticData.Info.Name;
            _perkDescription.text = perk.StaticData.Info.Description;
        }

        private void OnCloseClickHandler()
        {
            _perksManager.SetPerkAvailable(_currentPerk);
            Hide();
        }

        private void Start()
        {
            Hide();
        }

        private void OnEnable()
        {
            _player.Level.Subscribe(x => OnLevelUp(x)).AddTo(_disposables);
            _closeButton.onClick.AddListener(OnCloseClickHandler);
            _perkElement1.OnClick += OnElementClick;
            _perkElement2.OnClick += OnElementClick;
        }


        private void OnDisable()
        {
            _disposables.Clear();
            _closeButton.onClick.RemoveAllListeners();
            _perkElement1.OnClick -= OnElementClick;
            _perkElement2.OnClick -= OnElementClick;
        }
    }
}
