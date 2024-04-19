using System.Collections;
using System.Collections.Generic;
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
    public class SetOfChunks : ScriptableObject
    {
        [SerializeField] private List<ObjectToScroll> chunkList;

        public ObjectToScroll GetRandomChunk()
        {
            var randomIndex = Random.Range(0, chunkList.Count);
            var randomChunk = chunkList[randomIndex];
            return randomChunk;
        }

        public void CreateRandomChunk(Transform root)
        {
            var chunkPrefab = GetRandomChunk();
            Instantiate(chunkPrefab, root);
        }

    }

