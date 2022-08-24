using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//контролируем какие куски подсовывать в скролл менеджер
//логика выдавания кусков
//класс паттерна? то есть ассет с параметрами, согласно которому мы формируем участок трассы и окружение? ChunkSequenceData?
public class ChunkPipeline : MonoBehaviour
{
    //фабрика?
    #region fields
    [SerializeField] private ChunkDataset _chunks;
    #endregion

    public LayerChunk GetRandoCommonChunk()
    {
        return null;
    }
}
