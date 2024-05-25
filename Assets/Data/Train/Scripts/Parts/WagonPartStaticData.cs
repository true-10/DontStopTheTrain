using True10.StaticData;
using UnityEngine;

namespace DontStopTheTrain.Train
{
    public interface IWagonPartStaticData
    {
        public Information Information { get; }
        public WagonPartType Type { get; }
        public GameObject GamePrefab { get; }
        public GameObject BrokenGamePrefab { get; }
        public GameObject ConstructorPrefab { get; }
        public IWagonPartStaticData NextLevelStaticData { get; }

        //список мини игры?
        public int Price { get; }
        public int UpgradePrice { get; }
    }

    [CreateAssetMenu(fileName = "WagonPartStaticData", menuName = Constants.ContextMenuPaths.WAGON + "WagonPartStaticData")]
    public class WagonPartStaticData : ScriptableObject, IWagonPartStaticData
    {
        public Information Information => _information;
        public WagonPartType Type => _type;
        public GameObject GamePrefab => _gamePrefab;
        public GameObject BrokenGamePrefab => _gamePrefab;
        public GameObject ConstructorPrefab => _constructorPrefab;
        public IWagonPartStaticData NextLevelStaticData => _nextLevelStaticData;
        public int Price => _price;
        public int UpgradePrice => _upgradePrice;

        [SerializeField]
        private Information _information;
        [SerializeField]
        private WagonPartType _type;
        [SerializeField]
        private GameObject _gamePrefab;
        [SerializeField]
        private GameObject _brokenGamePrefab;
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
