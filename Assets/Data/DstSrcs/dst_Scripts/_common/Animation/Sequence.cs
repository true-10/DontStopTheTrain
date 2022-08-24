using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence_ : CMultiAnimation 
{
	#region fields

//	public CBaseAnimation[] m_sequence; 
	private int m_currentAnimation = 0;
	#endregion

	public override void Init () 
	{
		for (int i = 0; i < m_animations.Length; i++) 
		{
			m_animations [i].Init ();
		}
	}


	public override void Animation ( float t ) 
	{
		if (m_animations [m_currentAnimation].IsReached ()) 
		{
			m_currentAnimation++; 
		}
		if( m_animations[m_currentAnimation].m_isEnabled )
			m_animations [m_currentAnimation].Animation ( t );

	}
}
