using UnityEngine;

namespace DontStopTheTrain.Train.Constructor
{
    /// <summary>
    /// 
    /// 
    /// </summary>
    public class WagonSystemHolder : MonoBehaviour
    {
        public bool IsEmpty => _staticData == null;
        public WagonSystemStaticDataBase StaticData => _staticData;
        //  public IWagonSystem System => _system;

        [SerializeField]
        private WagonSystemStaticDataBase _staticData;
        [SerializeField]
        private WagonSystemObject _wagonSystemObject;
        [SerializeField]
        private WagonSystemType _systemType;

        public void SetSystemStatic(WagonSystemStaticDataBase staticData)
        {
            _staticData = staticData;
        }
    }
}
