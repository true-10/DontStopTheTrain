using True10.StaticData;
using UnityEngine;

namespace DontStopTheTrain.Train
{
    public interface IWagonSystemVisualData
    {
        public Information Information { get; }
        public WagonPartType Type { get; }
        public GameObject GamePrefab { get; }
        public GameObject BrokenGamePrefab { get; }
        public GameObject ConstructorPrefab { get; }

    }

    [CreateAssetMenu(fileName = "WagonSystemVisualData", menuName = Constants.ContextMenuPaths.WAGON + "WagonSystemVisualData")]
    public class WagonSystemVisualData : ScriptableObject, IWagonSystemVisualData
    {
        public Information Information => _information;
        public WagonPartType Type => _type;
        public GameObject GamePrefab => _gamePrefab;
        public GameObject BrokenGamePrefab => _gamePrefab;
        public GameObject ConstructorPrefab => _constructorPrefab;

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
