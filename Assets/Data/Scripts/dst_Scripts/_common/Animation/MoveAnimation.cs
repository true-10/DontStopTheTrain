using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAnimation : CBaseAnimation 
{
	#region fields
	//public Vector3 m_Axes = Vector3.zero;
	public Vector3 m_AxesRange = Vector3.zero;
	public Vector3 m_AxesSpeed = Vector3.zero;
	public float m_Speed = 5f;
	private Vector3 m_AxesCurrent = Vector3.zero;
	private Vector3 m_StartPos;

	private float m_progress = 0f;
	private float m_sign = 1f;
	#endregion
	// Use this for initialization

	public override void Init () 
	{
		base.Init ();
		m_StartPos = m_transform.localPosition;
	}


	public override void Animation ( float t ) 
	{

		m_progress += m_sign * t * m_Speed;
		//Debug.Log("m_progress = " + m_progress);
		if( ( m_progress > 1f ) || ( m_progress < 0f )  )
		{
			if (m_progress > 1f)
				m_progress = 1f;

			if (m_progress < 0f)
				m_progress = 0f;

			m_sign *= -1f;
		}
		//m_AxesCurrent = m_Axes * m_AxesSpeed * t;
		/*m_AxesCurrent.x += m_AxesSpeed.x * t;
		m_AxesCurrent.y += m_AxesSpeed.y * t;
		m_AxesCurrent.z += m_AxesSpeed.z* t;

		if (Mathf.Abs (m_AxesCurrent.x) > m_AxesRange.x) 
		{
			m_AxesSpeed.x *= -1f;

		}
		if (Mathf.Abs (m_AxesCurrent.y) > m_AxesRange.y) 
		{
			m_AxesSpeed.y *= -1f;

		}
		if (Mathf.Abs (m_AxesCurrent.z) > m_AxesRange.z )
		{
			//m_AxesCurrent.z = m_AxesRange.x * Mathf.Sign(m_AxesSpeed.x);
			m_AxesSpeed.z *= -1f;
		}
		*/
		//m_transform.Translate(m_AxesSpeed.x* t , m_AxesSpeed.y* t , m_AxesSpeed.z* t );

		//m_transform.localPosition = m_StartPos + m_AxesCurrent;
		//m_transform.localPosition = Vector3.Lerp (m_StartPos, m_StartPos + m_AxesCurrent, t);
		m_transform.localPosition = Vector3.Lerp (m_StartPos, m_StartPos + m_AxesRange, m_progress);
	}
}

