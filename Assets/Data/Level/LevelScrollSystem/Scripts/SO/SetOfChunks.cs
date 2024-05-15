using True10.LevelScrollSystem;
using True10.StaticData;
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

    [CreateAssetMenu(fileName = "SetOfChunks", menuName = "True10/LevelScrollSystem/SetOfChunks")]
    public sealed class SetOfChunks : StaticStorage<LevelChunk>
    {
        public BiomType BiomType => _biomType;
        public LevelChunk StationChunk => _station;

        [SerializeField]
        private BiomType _biomType;
        [SerializeField]
        private LevelChunk _station;

        public LevelChunk CreateRandomObject(Transform root)
        {
            var chunkPrefab = GetRandomItem();
            var newObject = Instantiate(chunkPrefab, root);
            return newObject;
        }
    }
}
