using System;
using System.Collections.Generic;

/// <summary>
/// статическая модель данных списка брони
/// </summary>
[Serializable]
public class ArmorsStaticData
{
    List<ArmorStaticData> Armors = new List<ArmorStaticData>();
}

/// <summary>
/// статическая модель данных брони
/// </summary>
[Serializable]
public class ArmorStaticData
{
    public int Id;
}
