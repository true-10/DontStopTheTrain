using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAnimation
{
    #region fields
    bool _isEnabled { get; set; }
    bool _isReached { get; set; }

    #endregion

    void OnUpdate(float t);
    void Start();
    void Start(float speed);
    bool IsReached();
}

public class CBaseAnimation : MonoBehaviour 
{
	#region fields
	public bool	m_isEnabled = true;

	public bool	m_isCycle = true;
	public bool	m_isPart = false;

	private bool m_isReached = false;

	protected Transform m_transform;
	#endregion

	public virtual void Init () 
	{

		m_transform = GetComponent<Transform> ();	
	}


	public virtual void Animation ( float t ) 
	{
		
	}

	public bool IsReached()
	{
		return m_isReached;
	}
}
