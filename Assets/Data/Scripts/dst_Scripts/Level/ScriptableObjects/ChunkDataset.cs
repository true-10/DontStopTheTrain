using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChunkDataset", menuName = "DST/ChunkDataset")]
public class ChunkDataset : ScriptableObject
{
    #region fields
    [SerializeField] private List<LayerChunk> _roadChunks;
    [SerializeField] private List<LayerChunk> _commonChunks;
    [SerializeField] private List<LayerChunk> _specChunks;
    [SerializeField] private List<LayerChunk> _stationChunks;


    [SerializeField] private List<LayerChunk> _commonChunksBG1;
    [SerializeField] private List<LayerChunk> _specChunksBG1;

    [SerializeField] private List<LayerChunk> _commonChunksBG2;
    [SerializeField] private List<LayerChunk> _specChunksBG2;
    #endregion

    public LayerChunk GetRandomRoadChunk()
    {
        int index = Random.Range(0, _roadChunks.Count - 1);
        return _roadChunks[index];
    }

    public LayerChunk GetRandomCommonChunk()
    {
        int index = Random.Range(0, _commonChunks.Count - 1);
        return _commonChunks[index];
    }

    public LayerChunk GetRandomSpecChunk()
    {
        int index = Random.Range(0, _specChunks.Count - 1);
        return _specChunks[index];
    }

    public LayerChunk GetRandomStationChunk()
    {
        int index = Random.Range(0, _stationChunks.Count - 1);
        return _stationChunks[index];
    }
}
