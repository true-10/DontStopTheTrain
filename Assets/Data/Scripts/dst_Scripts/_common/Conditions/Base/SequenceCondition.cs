using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//все условия выполняются по очереди
public class SequenceCondition : ICondition
{
    private int currentIndex = 0;
    public ICondition[] conditions;
    private bool finalResult = false;


    public void OnStart()
    {
        for (int i = 0; i < conditions.Length; i++)
        {
            conditions[i].OnStart();
        }
    }
    public void OnUpdate()
    {
        if (finalResult) return;
        if(conditions[currentIndex].IsReached() )
        {
            conditions[currentIndex].PostUpdate();
            if (currentIndex == conditions.Length - 1)
            {
                finalResult = true;
            }
            else
            {
                currentIndex++;
            }
        }
        else
        {
            conditions[currentIndex].OnUpdate();
        }
    }

    public  void PostUpdate()
    {
        //for (int i = 0; i < conditions.Length; i++)
        {
          //  conditions[i].PostUpdate();
        }
    }

    public  bool IsReached()
    {
        return finalResult;
    }
}
