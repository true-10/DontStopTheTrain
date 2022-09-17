using System.Collections;
using System.Collections.Generic;


public interface IVehiclePartStaticDataManager 
{
    List<VehiclePartStaticData> GetAllParts();
    List<WeaponStaticData> GetAllWeapons();//?
    List<ArmorStaticData> GetAllArmors();//?
}
