using System;
using System.Collections.Generic;


/// <summary>
/// статическая модель данных списка запчастей
/// </summary>
[Serializable]
public class VehiclePartsStaticData
{
    public List<VehiclePartStaticData> VehicleParts = new List<VehiclePartStaticData>();
}

/// <summary>
/// статическая модель данных запчасти
/// </summary>
[Serializable]
public class VehiclePartStaticData
{
    public int Id;

    //уровень апгрейда
    public int Hp; //ресурс/здоровье
    public int TypeId;//айди запчасти из списка по Type. типа если колеса, то айди для списка колес
    public VehiclePartType Type;//тип запчасти? int?

    
    public string Name;//имя
    public string Model;//3д модель
    public string Description;//описание
    public string IconName;//иконка
    //позиции для установки (куда можно установить эту запчасть)

    public int Price;//цена
}


/// <summary>
/// типы запчасти
/// </summary>
public enum VehiclePartType
{
    Engine = 1,//двигатель
    Wheel = 2,
    Armor = 3,
    Weapon = 4,
    Transmission = 5,//трансмиссия
    
}

/// <summary>
/// типы коннекторов для запчастей
/// </summary>
public enum VehiclePartPositionType
{
    Wheel,
    Armor,
    Weapon,
    //трансми
}