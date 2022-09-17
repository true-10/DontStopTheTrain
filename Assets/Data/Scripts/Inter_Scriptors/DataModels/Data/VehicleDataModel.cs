using System;
using System.Collections.Generic;


/// <summary>
/// статическая модель данных списка тачек
/// </summary>
[Serializable]
public class VehiclesStaticData
{
    public List<VehicleStaticData> Vehicles = new List<VehicleStaticData>();
}

/// <summary>
/// статическая модель данных транспортного средства
/// </summary>
[Serializable]

public class VehicleStaticData
{
    public int Id;
    //тип машины
    //список способностей
    //3д модель
    //имя
    //описание
    //иконка
    //цена?

}
