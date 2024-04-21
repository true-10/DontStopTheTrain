using UnityEngine;

namespace True10.LevelScrollSystem
{
    [CreateAssetMenu(fileName = "ChunkStaticData", menuName = "DST/Level/ChunkStaticData")]
    public class ChunkStaticData : ScriptableObject
    {
        public int Weight => _weight;
        public ChunkType Type => _type;
        public BiomType BiomType => _biomType;

        [SerializeField]
        private int _weight;
        [SerializeField]
        private ChunkType _type;
        [SerializeField]
        private BiomType _biomType;
    }

    public enum ChunkType
    {
        Simple,
        Station

    }

    public enum BiomType
    {
        City,
        Desert,
        Forest,


    }
}
