using True10.StaticData;
using UnityEngine;

namespace DontStopTheTrain.Train
{
    public interface IWagonSystemVisualData
    {
        public Information Information { get; }
        public WagonPartType Type { get; }
        public GameObject Prefab { get; }
        public GameObject BrokenPrefab { get; }
       // public GameObject ConstructorPrefab { get; }

    }

    [CreateAssetMenu(fileName = "WagonSystemVisualData", menuName = Constants.ContextMenuPaths.WAGON + "WagonSystemVisualData")]
    public class WagonSystemVisualData : ScriptableObject, IWagonSystemVisualData
    {
        public Information Information => _information;
        public WagonPartType Type => _type;
        public GameObject Prefab => _prefab;
        public GameObject BrokenPrefab => _prefab;
      //  public GameObject ConstructorPrefab => _constructorPrefab;

        [SerializeField]
        private Information _information;
        [SerializeField]
        private WagonPartType _type;
        [SerializeField]
        private GameObject _prefab;
        [SerializeField]
        private GameObject _brokenPrefab;
    //    [SerializeField]
      //  private GameObject _constructorPrefab;
       // private List<WagonSystemStaticDataBase> _systemStaticDatas;

    }

    public enum WagonPartType
    {
        Visual = 0,
        Cart_2x,
        Cart_3x,
        LocoWheel,
        Engine,
        Hull
    }

}
