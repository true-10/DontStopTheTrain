using System;
using System.Collections.Generic;


/// <summary>
/// ����������� ������ ������ ������ ���������
/// </summary>
[Serializable]
public class VehiclePartsStaticData
{
    public List<VehiclePartStaticData> VehicleParts = new List<VehiclePartStaticData>();
}

/// <summary>
/// ����������� ������ ������ ��������
/// </summary>
[Serializable]
public class VehiclePartStaticData
{
    public int Id;

    //������� ��������
    public int Hp; //������/��������
    public int TypeId;//���� �������� �� ������ �� Type. ���� ���� ������, �� ���� ��� ������ �����
    public VehiclePartType Type;//��� ��������? int?

    
    public string Name;//���
    public string Model;//3� ������
    public string Description;//��������
    public string IconName;//������
    //������� ��� ��������� (���� ����� ���������� ��� ��������)

    public int Price;//����
}


/// <summary>
/// ���� ��������
/// </summary>
public enum VehiclePartType
{
    Engine = 1,//���������
    Wheel = 2,
    Armor = 3,
    Weapon = 4,
    Transmission = 5,//�����������
    
}

/// <summary>
/// ���� ����������� ��� ���������
/// </summary>
public enum VehiclePartPositionType
{
    Wheel,
    Armor,
    Weapon,
    //�������
}