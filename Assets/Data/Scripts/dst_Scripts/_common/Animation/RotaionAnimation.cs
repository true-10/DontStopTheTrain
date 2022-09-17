using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotaionAnimation : CBaseAnimation 
{
	#region fields
	public Vector3 m_Angles = Vector3.zero;

	public Vector3 m_Limits = Vector3.zero;

	private Vector3 m_Targets = Vector3.zero;
	private Vector3 m_Prevs = Vector3.zero;
	#endregion
	// Use this for initialization

	public override void Init () 
	{
		base.Init ();
		m_Targets = m_Limits;
		m_Prevs = m_transform.localRotation.eulerAngles;
	}


	public override void Animation ( float t ) 
	{

		if (m_isCycle)
			CycleAnimation (t);
		else
			NoneCycleAnimation (t);
	}

	public void CycleAnimation ( float t ) 
	{

		m_transform.Rotate (m_Angles.x , m_Angles.y , m_Angles.z );
	}


	public void NoneCycleAnimation ( float t ) 
	{
		Vector3 eulers = Vector3.Lerp (m_Prevs, m_Targets, t);
		Quaternion newRot = m_transform.localRotation;
		newRot.eulerAngles = eulers;
		m_transform.localRotation = newRot;

	}
}
