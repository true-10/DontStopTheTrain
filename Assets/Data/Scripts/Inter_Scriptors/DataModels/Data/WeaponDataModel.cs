using System;
using System.Collections.Generic;


/// <summary>
/// статическая модель данных списка оружия
/// </summary>
[Serializable]
public class WeaponsStaticData
{
    public List<WeaponStaticData> Weapons = new List<WeaponStaticData>();
}

/// <summary>
/// статическая модель данных оружия
/// </summary>
[Serializable]
public class WeaponStaticData
{
    public int Id;
    //тип
    //урон
    //емкость магазина
    //время перезарядки
    //эффекты?
}
