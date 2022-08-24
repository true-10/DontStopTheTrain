using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAnimationController : CMultiAnimation {

	// Use this for initialization
	void Awake () 
	{
		Init ();
	}

	void LateUpdate () 
	{
		Animation (Time.deltaTime);
	}

	public override void Init () 
	{
		m_transform = GetComponent<Transform> ();
		m_animations = FindObjectsOfType<CBaseAnimation> ();
		//base.Init ();

		for (int i = 0; i < m_animations.Length; i++) 
		{
			if(m_animations[i] != this )
				m_animations [i].Init ();
		}
	}


	public override void Animation ( float t ) 
	{

		for (int i = 0; i < m_animations.Length; i++) 
		{
			if (m_animations [i] != this) 
			{
				if (m_animations [i].m_isEnabled)
					m_animations [i].Animation (t);
			}
		}
	}
}
