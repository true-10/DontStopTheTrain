using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowardsToTarget : CBaseAnimation 
{
	#region fields

		public Transform	m_target;
	#endregion

	public override void Init () 
	{
		base.Init ();

	}


	public override void Animation ( float t ) 
	{
		m_transform.rotation = Quaternion.LookRotation ((m_transform.position - m_target.position).normalized );
	}
}

