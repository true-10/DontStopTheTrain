using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class TickManager : AbstractManager
{
    private Dictionary<ITick, int> ticks = new Dictionary<ITick, int>();

    [Inject]
    private TimerManager timerManager;

    public event Action OnTick;

    public const float tickPeriod = 1.0f;

    private DateTime timePaused;
    private bool isPaused;

   /* public override void OnInit()
    {
        timerManager.AddTimer("Tick", Tick, tickPeriod, true);
    }*/

    public void StopTicking()
    {
        timerManager.ClearTimers();
    }

    public void Add(ITick tick, int order = 0)
    {
        ticks.Add(tick, order);
        var ordered = ticks.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        ticks = ordered;
    }

    public void Remove(ITick tick)
    {
        if (ticks.ContainsKey(tick)) ticks.Remove(tick);
    }

    public void Tick()
    {
        foreach (var tick in ticks)
        {
            tick.Key?.Tick(tickPeriod);
        }
        OnTick?.Invoke();
    }

    public void Tick(float forcedTime)
    {
        foreach (var tick in ticks)
        {
            tick.Key?.Tick(forcedTime);
        }

        OnTick?.Invoke();
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause && !isPaused)
        {
            isPaused = true;
            timePaused = DateTime.Now;
        }
        else
        {
            if (isPaused)
            {
                isPaused = false;
                var time = (float)(DateTime.Now - timePaused).TotalSeconds;
                Tick(time);
            }
        }
    }
}

public interface ITick
{
    void Tick(float tickPeriod);
}
