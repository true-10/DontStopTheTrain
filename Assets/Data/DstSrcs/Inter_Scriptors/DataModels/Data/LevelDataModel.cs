using System;
using System.Collections.Generic;

/// <summary>
///модель данных уровня
/// </summary>

[Serializable]
public class LevelStaticData
{
    //тип уровня?
    //типы покрытия
    //список моделей кусков

}

/// <summary>
/// это последовательность кусков одной местности. лес, например. или город. или переходная
/// </summary>
[Serializable]
public class ChunkSequenceStaticData
{
    public int SeqType; // 0 - обычная, 1 - переходная,
    public string Comment;
}

/// <summary>
/// 
/// </summary>
[Serializable]
public class ChunkStaticData
{
    public string PrefabName;
    public string Comment;

    //повторяемый кусок для зацикливания или уникальный


}
