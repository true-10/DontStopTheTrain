using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMultiAnimation :  CBaseAnimation
{
	#region fields

		public CBaseAnimation[] m_animations; 
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

		for (int i = 0; i < m_animations.Length; i++) 
		{
			if( m_animations[i].m_isEnabled )
				m_animations [i].Animation ( t );
		}
	}
}
