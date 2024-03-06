using System.Collections.Generic;
using UnityEngine;

namespace DontStopTheTrain.Train
{
    public class WagonStaticDataBase : ScriptableObject, IWagonStaticData
    {
        public int Id => _id;
        public Information Info => _info;


        public virtual WagonType Type => WagonType.Empty;
       // public List<int> wagonEvents;


        [SerializeField, Min(0)]
        private int _id;
        [SerializeField]
        private Information _info;
    }
}
