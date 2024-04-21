using True10.LevelScrollSystem;
using UnityEngine;

namespace True10.LevelScrollSystem
{
    [System.Serializable]
    public struct SetOfChunksComponent
    {
        public SetOfChunks Chunks;
        public Transform Root;
        public int Count;
    }
}

    [CreateAssetMenu(fileName = "SetOfChunks", menuName = "True10/LevelScrollSystem/SetOfChunks")]
    public sealed class SetOfChunks : SetOfObjects<LevelChunk>
    {
        public BiomType BiomType => _biomType;

        [SerializeField]
        private BiomType _biomType;
    }
