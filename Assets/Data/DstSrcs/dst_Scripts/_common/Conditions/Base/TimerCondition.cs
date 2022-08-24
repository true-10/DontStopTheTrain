using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerCondition : ICondition
{
    public float seconds;
    Timer timer;

    public  void OnStart()
    {
        timer = new Timer();
        timer.Start(seconds);
    }
    public  void OnUpdate()
    {

    }

    public void PostUpdate()
    {
    }

    public  bool IsReached()
    {
        return timer.IsCompleted();
    }
}
