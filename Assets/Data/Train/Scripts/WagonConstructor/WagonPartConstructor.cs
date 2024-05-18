using System.Collections.Generic;
using UnityEngine;

namespace DontStopTheTrain.Train.Constructor
{
    public class WagonPartConstructor : MonoBehaviour
    {
        public WagonPartStaticData StaticData => _staticData;

        [SerializeField]
        private WagonPartStaticData _staticData;
    }


    public class WagonPartsContainer : MonoBehaviour
    {

        [SerializeField]
        private List<WagonPartHolder> _partHoiders;
    }

    /// <summary>
    /// 
    /// 
    /// </summary>
    public class WagonPartHolder : MonoBehaviour
    {
        public bool IsEmpty => _part == null;
        public WagonPart Part => _part;

        [SerializeField]
        private WagonPart _part;
    }
}
