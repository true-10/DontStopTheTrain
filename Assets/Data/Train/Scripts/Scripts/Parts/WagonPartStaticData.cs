using True10.StaticData;
using UnityEngine;

namespace DontStopTheTrain.Train
{
    [CreateAssetMenu(fileName = "WagonPartStaticData", menuName = Constants.ContextMenuPaths.WAGON + "WagonPartStaticData")]
    public class WagonPartStaticData : ScriptableObject
    {

        [SerializeField]
        private Information _information;
        [SerializeField]
        private WagonPartType _type;
        [SerializeField]
        private GameObject _gamePrefab;
        [SerializeField]
        private GameObject _constructorPrefab;
        [SerializeField]
        private WagonSystemStaticDataBase _systemStaticData;
       // private List<WagonSystemStaticDataBase> _systemStaticDatas;

    }

    public enum WagonPartType
    {
        Visual = 0,
        Cart_2x,
        Cart_3x,
        LocoWheel,
        Engine
    }

}
