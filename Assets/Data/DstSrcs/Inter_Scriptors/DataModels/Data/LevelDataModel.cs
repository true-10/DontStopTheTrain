using System;
using System.Collections.Generic;

/// <summary>
///������ ������ ������
/// </summary>

[Serializable]
public class LevelStaticData
{
    //��� ������?
    //���� ��������
    //������ ������� ������

}

/// <summary>
/// ��� ������������������ ������ ����� ���������. ���, ��������. ��� �����. ��� ����������
/// </summary>
[Serializable]
public class ChunkSequenceStaticData
{
    public int SeqType; // 0 - �������, 1 - ����������,
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

    //����������� ����� ��� ������������ ��� ����������


}
