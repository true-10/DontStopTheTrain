using DontStopTheTrain.Train;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using True10.Managers;
using UnityEngine;

namespace DontStopTheTrain
{
    public class WagonsManager : DataManager<IWagon>
    {
        public override void Initialize()
        {

        }

        public override void Dispose()
        {
            Clear();
        }

        public Locomotive GetLocomotive()
        {
            return Items.Where(wagon => wagon is Locomotive).FirstOrDefault() as Locomotive;
        }
    }

    public class WagonSystemsManager : DataManager<IWagonSystem>
    {
        public override void Initialize()
        {

        }

        public override void Dispose()
        {
            Clear();
        }

    }
}
