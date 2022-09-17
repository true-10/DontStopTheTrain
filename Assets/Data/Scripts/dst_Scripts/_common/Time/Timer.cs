using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Serializable]
public class Timer 
{
    #region fields
        //[SerializeField]
        protected float m_seconds;
        //[SerializeField]
        protected float m_currentTime;
        //[SerializeField]
        protected bool m_isStarted;
        //[SerializeField]
        protected bool m_isCompleted;

    #endregion
    public Timer()
    {
        m_seconds = 0f;
        m_currentTime = 0f;
        m_isStarted = false;
        m_isCompleted = false;
    }

    public void Start(float seconds)
    {
        m_seconds = seconds;
        m_currentTime = 0f;
        m_isStarted = true;
        m_isCompleted = false;
      //  Debug.Log("Timer m_seconds  = " + m_seconds + " m_isStarted = " + m_isStarted + " m_isCompleted " + m_isCompleted);
    }

    public void Stop()
    {
        m_seconds = 0f;
        m_currentTime = 0f;
        m_isStarted = false;
        m_isCompleted = false;
    }

    public bool IsCompleted()
    {
        return m_isCompleted;
    }

    public bool IsInProcess()
    {
        return m_isStarted;
    }

    public float GetProgress()
    {
        if (m_seconds < 0.001f) return 0f;

        return m_currentTime / m_seconds;
    }

    public void OnUpdate(/* float deltaTime*/)
    {
        //Debug.Log("Timer m_seconds  = " + m_seconds + " m_isStarted = " + m_isStarted + " m_isCompleted " + m_isCompleted);
        if (m_isCompleted) return;
        if (!m_isStarted) return;
        m_currentTime += GTime.gDeltaTime ;
        //Debug.Log("Timer OnUpdate()) m_currentTime = " + m_currentTime);
        if ( m_currentTime > m_seconds)
        {
            m_isStarted = false;
            m_isCompleted = true;
        }
    }
}
