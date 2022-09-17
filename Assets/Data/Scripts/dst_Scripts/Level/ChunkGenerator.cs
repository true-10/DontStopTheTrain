using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//фабрика?
//генерим нужные куски мира
public class ChunkGenerator : MonoBehaviour
{
    #region fields
    [SerializeField] private ChunkDataset _dataset;
   // [SerializeField] private Transform _chunkRoot;

    #endregion

        
    public void PrewarmGeneration(Transform parent, int numb)
    {//заргужаем сразу нужное кол-во кусков
        //перенести в левел конроллер? пайплайн? в другой короче скрипт
    }

    public LayerChunk GetRoadChunk(Transform parent)
    {
        LayerChunk chunk = Instantiate(_dataset.GetRandomRoadChunk(), parent);
        return chunk;
    }


    public LayerChunk GetStationChunk(Transform parent)
    {
        LayerChunk chunk = Instantiate(_dataset.GetRandomStationChunk(), parent);
        return chunk;
    }
}
