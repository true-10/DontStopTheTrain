using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DontStopTheTrain.Train.Constructor
{

    public class WagonPartView : BaseClickableView
    {
        public WagonPartStaticData StaticData => _staticData;

        [SerializeField]
        private WagonPartStaticData _staticData;

        public override void Dispose()
        {
            base.Dispose();
        }

        public override void Initialize()
        {
            base.Initialize();
        }

    }
}
