using System.Collections.Generic;
using UnityEngine;

public class SetOfObjects<T> : ScriptableObject where T : Object
{
    [SerializeField] private List<T> chunkList;

    public T GetRandomChunk()
    {
        var randomIndex = Random.Range(0, chunkList.Count);
        var randomChunk = chunkList[randomIndex];
        return randomChunk;
    }

    public T CreateRandomChunk(Transform root)
    {
        var chunkPrefab = GetRandomChunk();
        var newObject =  Instantiate(chunkPrefab, root);
        return newObject;
    }

}
