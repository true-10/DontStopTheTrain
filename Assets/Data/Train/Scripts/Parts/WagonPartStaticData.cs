using True10.StaticData;
using UnityEngine;

namespace DontStopTheTrain.Train
{
    [CreateAssetMenu(fileName = "WagonPartStaticData", menuName = Constants.ContextMenuPaths.WAGON + "WagonPartStaticData")]
    public class WagonPartStaticData : ScriptableObject
    {
        public Information Information => _information;
        public WagonPartType Type => _type;
        public GameObject GamePrefab => _gamePrefab;
        public GameObject ConstructorPrefab => _constructorPrefab;
        public WagonPartStaticData NextLevelStaticData => _nextLevelStaticData;
        public int Price => _price;
        public int UpgradePrice => _upgradePrice;

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
        [SerializeField]
        private WagonPartStaticData _nextLevelStaticData;
        [SerializeField]
        private int _price;
        [SerializeField]
        private int _upgradePrice;
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
