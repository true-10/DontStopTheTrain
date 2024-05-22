using System.Collections;
using System.Collections.Generic;
using True10.Interfaces;
using UnityEngine;
using Zenject;

namespace DontStopTheTrain.Train
{
    public class WagonObject : AbstractGameLifeCycleBehaviour
    {
        public IWagon WagonData => _wagonData;

        [Inject]
        private WagonsFabric _fabric;

        [SerializeField]
        private WagonStaticDataBase _wagonStaticData;

        private IWagon _wagonData;


        public override void Initialize()
        {
            _wagonData = _fabric.Create(_wagonStaticData);
            _wagonData.Initialize();
        }

        public override void Dispose()
        {
            _wagonData.Dispose();
        }
    }
}
