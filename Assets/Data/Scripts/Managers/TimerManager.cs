using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : AbstractManager
{
    #region excluded timers
    private const string TICK_TIMER = "Tick";
    #endregion

    private List<TimerData> timers;

    public Action OnInited;
        
    private bool isInited = false;

    public override void OnInit()
    {
        throw new NotImplementedException();
    }

    private void OnDestroy()
    {
        Dispose();
    }

    public override void Init()
    {
        if (timers == null) timers = new List<TimerData>();

        base.Init();
        OnInited?.Invoke();
    }


    public override void Dispose()
    {
        ClearTimers();
    }

    public void AddTimer(string id, Action action, float period, bool repeat)
    {
        var timer = new TimerData()
        {
            Id = id,
            Action = action,
            EndTime = DateTime.UtcNow.AddSeconds(period),
            Period = period,
            Repeat = repeat,
        };
        timers.Add(timer);
    }

    public TimerData GetTimer(string id)
    {
        return timers.FirstOrDefault(x => x.Id == id);
    }

    public void RemoveTimer(string id)
    {
        // Вызывает бесконечный цикл, если в колбере есть вызов RemoveTimer в попытке удалить этот таймер.
        //foreach (var t in timers.Where(x => x.Id == id))
        //{
        //    t.Action?.Invoke();
        //}
        timers.RemoveAll(x => x.Id == id);
    }

    public void ClearTimers()
    {
        if (timers != null)
        {
            timers.Clear();
        }
    }

    private void Update()
    {
        if (!isInited)
            return;

        bool needsRemove = false;
        for (int i = 0; i < timers.Count; i++)
        {
            var timer = timers[i];
            if (timer.Time <= 0)
            {
                try
                {
                    if (timer.Id != TICK_TIMER)
                    {
                        //UnityEngine.Debug.LogError($"[Timer -> {timer.Id}] Action");
                    }
                    timer.Action?.Invoke();
                }
                catch (Exception e)
                {
                    UnityEngine.Debug.LogError($"[Exception] Timer ({timer.Id}): {e}");
                    timer.IsCompleted = true;
                }

                if (timer.Repeat)
                {
                    timer.EndTime = DateTime.UtcNow.AddSeconds(timer.Period);
                }
                else
                {
                    needsRemove = true;
                    timer.IsCompleted = true;
                }
            }
        }

        if (needsRemove)
        {
            timers.RemoveAll(x => x.IsCompleted | x.Action == null);
        }
    }

}

[System.Serializable]
public class TimerData
{
    public string Id;
    public string CustomData;
    [NonSerialized] public Action Action;
    public float Time => (float)(EndTime - DateTime.UtcNow).TotalSeconds;
    public DateTime EndTime;
    public DateTime RunTime;
    public float Period;
    public bool Repeat;
    public bool IsSaved;
    public bool IsCompleted;
}