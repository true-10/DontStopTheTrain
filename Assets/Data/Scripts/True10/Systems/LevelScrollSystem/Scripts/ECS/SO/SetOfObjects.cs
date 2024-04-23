using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SetOfObjects<T> : ScriptableObject where T : Object
{
    public IReadOnlyCollection<T> Items => _items.ToList();

    [SerializeField] private List<T> _items;

    public T GetRandomItem()
    {
        var randomIndex = Random.Range(0, _items.Count);
        var randomChunk = _items[randomIndex];
        return randomChunk;
    }

    public T CreateRandomObject(Transform root)
    {
        var chunkPrefab = GetRandomItem();
        var newObject =  Instantiate(chunkPrefab, root);
        return newObject;
    }

}
