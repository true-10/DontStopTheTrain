using UnityEngine;

namespace True10.LevelScrollSystem
{
    [CreateAssetMenu(fileName = "ChunkStaticData", menuName = "DST/Level/ChunkStaticData")]
    public class ChunkStaticData : ScriptableObject
    {
        public int Weight => _weight;
        public ChunkType Type => _type;

        [SerializeField]
        private int _weight;
        [SerializeField]
        private ChunkType _type;
    }

    public enum ChunkType
    {
        Simple,
        Station

    }
}
