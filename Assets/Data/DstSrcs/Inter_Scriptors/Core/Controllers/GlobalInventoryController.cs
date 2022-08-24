using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGlobalInventoryController
{

}

/// <summary>
/// хранит инфу о всех айтемах
/// </summary>
public class GlobalInventoryController : IGlobalInventoryController, IGameLifeCycle
{
    //датаменеджер


    public void Dispose()
    {
        throw new System.NotImplementedException();
    }

    public void Init()
    {
        throw new System.NotImplementedException();
    }
}
