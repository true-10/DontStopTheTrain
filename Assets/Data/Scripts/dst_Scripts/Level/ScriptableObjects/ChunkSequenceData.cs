using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChunkSeqData", menuName = "DST/ChunkSeqData")]
public class ChunkSequenceData : ScriptableObject
{
    #region fields
    public bool _isForcedSequence; //если куски должны идти в строгой последовательности. например для перехода от снега к лесу, что бы плавный переход был
         
    public int _iterationCount; //кол-во циклов? если _isForcedSequence == true, то кол-во равно длине списка
    public LayerChunk _startChunk;//начало цикла            нужны ли?
    public List<LayerChunk> _midChunks;//цикл
    public LayerChunk _endChunk;//конец цикла               нужны ли?
    #endregion
}
