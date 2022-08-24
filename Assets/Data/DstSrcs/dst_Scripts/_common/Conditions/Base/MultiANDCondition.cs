using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//если все условия тру, то результат тру будет
public class MultiANDCondition : ICondition
{
    public ICondition[] conditions;

    public void OnStart()
    {
        for (int i = 0; i < conditions.Length; i++)
        {
            conditions[i].OnStart();
        }
    }
    public void OnUpdate()
    {
        for (int i = 0; i < conditions.Length; i++)
        {
            conditions[i].OnUpdate();
        }
    }


    public void PostUpdate()
    {
        for (int i = 0; i < conditions.Length; i++)
        {
            conditions[i].PostUpdate();
        }
    }

    public bool IsReached()
    {
        bool result = false;

        for (int i = 0; i < conditions.Length; i++)
        {
            result &= conditions[i].IsReached();
        }
        if (result) PostUpdate();
        return result;
    }
}
