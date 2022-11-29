using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DontStopTheTrain.Train
{
    [System.Serializable]
    public class WagonDataScriptableStaticData
    {
        public string Name;
        public int Number;
        public int WagonType;
        public List<int> wagonEvents;
    }


    [CreateAssetMenu(fileName = "WagonDataScriptableObject", menuName = "DST/WagonDataSO")]
    public class WagonDataScriptableObject : ScriptableObject
    {
        public WagonDataScriptableStaticData data;
    }
}
