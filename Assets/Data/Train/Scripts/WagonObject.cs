using System.Collections;
using System.Collections.Generic;
using System.Linq;
using True10.Interfaces;
using UnityEngine;
using Zenject;

namespace DontStopTheTrain.Train
{
    public class WagonObject : AbstractGameLifeCycleBehaviour
    {
        public IWagon WagonData => _wagonData;
        private IReadOnlyCollection<WagonSystemObject> WagonSystemObjects => _wagonSystemObjects;

        [Inject]
        private WagonsFabric _fabric;        
        [Inject]
        private WagonObjectsManager _wagonObjectsManager;
        [Inject]
        private WagonsManager _wagonsManager;

        [SerializeField]
        private WagonStaticDataBase _wagonStaticData;

        private IWagon _wagonData;
        private List<WagonSystemObject> _wagonSystemObjects;

        public override void Initialize()
        {
            _wagonData = _fabric.Create(_wagonStaticData);
            _wagonData.Initialize();
            _wagonObjectsManager.TryToAdd(this);
            _wagonsManager.TryToAdd(_wagonData);
            _wagonSystemObjects ??= GetComponentsInChildren<WagonSystemObject>().ToList();
        }

        public override void Dispose()
        {
            _wagonData.Dispose();
            _wagonObjectsManager.TryToRemove(this);
            _wagonsManager.TryToRemove(_wagonData);
        }

        private void OnValidate()
        {
            _wagonSystemObjects ??= GetComponentsInChildren<WagonSystemObject>().ToList();
        }
    }
}
