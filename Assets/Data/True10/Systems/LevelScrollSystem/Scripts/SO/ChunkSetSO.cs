using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace True10.LevelScrollSystem
{
    [CreateAssetMenu(fileName = "ChunkSetSO", menuName = "Interceptors/SO/ChunkSetSO", order = 2)]
    public class ChunkSetSO : ScriptableObject
    {
        [SerializeField] private ChunkSet chunkSet;
    }
}
