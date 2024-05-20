using DontStopTheTrain.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace DontStopTheTrain.Train.Constructor
{
    public class WagonPartView : BaseClickableView
    {
        public WagonPartStaticData StaticData => _staticData;

        [Inject]
        private SystemUpgrader _partUpgrader;
        [Inject]
        private UIContainer _UIContainer;

        [SerializeField]
        private WagonPartStaticData _staticData;
        [SerializeField]
        private GameObject _selectionObject;

        public override void Dispose()
        {
            base.Dispose();
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void OnClickViewHandler()
        {
            _partUpgrader.SetCurrentTarget(gameObject);
            _partUpgrader.SetCurrentSystemStatic(_staticData);
            _selectionObject?.SetActive(false);
            _UIContainer.GetUIScreen(UIScreenID.PartUpgrader)?.Show();
        }

        protected override void OnExitViewHandler()
        {
            _selectionObject?.SetActive(false);
            _partUpgrader.SetCurrentTarget(null);
            _partUpgrader.SetCurrentSystemStatic(null);
        }

        protected override void OnMouseOverEnterHandler()
        {
            _selectionObject?.SetActive(true);
        }

        protected override void OnMouseOverExitHandler()
        {
            _selectionObject?.SetActive(false);
        }
    }
}
