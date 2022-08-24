using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//последовательности одной местности
//последовательности перехода от одной к другой

public enum SeqType
{
    ST_Desert = 0,
    ST_Snow_Light,//немного снега
    ST_Snow_Heavy,//сугробы
    ST_City,
    ST_Forest,
}
public class ChunkSequence// : MonoBehaviour
{
    #region fields
    ChunkSequenceData _data;
    public SeqType _inType; //если последовательность однотипная, то вход и выход равны
    public SeqType _outType;//если нет, то мы знаем какой вариант может подсунуть следующий
    //сделать список(?) последовательностей который могут подойти к следующему и из него рандомно подставлять?

    #endregion
    public ChunkSequence (ChunkSequenceData data)
    {

    }
}
