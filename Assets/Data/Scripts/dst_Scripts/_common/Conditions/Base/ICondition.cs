using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICondition
{
    void OnStart();
    void OnUpdate();
    void PostUpdate();


    bool IsReached();
}
