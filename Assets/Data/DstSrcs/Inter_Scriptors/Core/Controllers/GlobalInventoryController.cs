using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGlobalInventoryController
{

}

/// <summary>
/// ������ ���� � ���� �������
/// </summary>
public class GlobalInventoryController : IGlobalInventoryController, IGameLifeCycle
{
    public Action OnInit { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    //������������


    public void Dispose()
    {
        throw new System.NotImplementedException();
    }

    public void Init()
    {
        throw new System.NotImplementedException();
    }
}
