using System;
using System.Collections.Generic;

/// <summary>
/// ����������� ������ ������ ������ �����
/// </summary>
[Serializable]
public class ArmorsStaticData
{
    List<ArmorStaticData> Armors = new List<ArmorStaticData>();
}

/// <summary>
/// ����������� ������ ������ �����
/// </summary>
[Serializable]
public class ArmorStaticData
{
    public int Id;
}
