using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPathAnimation : MonoBehaviour 
{
	#region fields
	public		bool			m_Active = false;
	/*{
		set
		{
			m_Active = value;
			if( value )
			{
				if( !m_Emitting.isPlaying )
					m_Emitting.Play();
			}
			else
			{
				if( m_Emitting.isPlaying )
					m_Emitting.Stop();
			}
		}
		get
		{
			return m_Active;
		}
	} = false;*/
	public		bool			m_Loop			= false;
	protected		bool			m_TimeToLoop			= false;
	protected		bool			m_Disable			= false;
	public		float			m_speed			= 1f;
	protected	int			m_currentIndex 	= 0;
	protected	int			m_count 		= 0;
	public 		Transform[] m_points;

	protected	Vector3		m_nextPos 		= Vector3.zero;
	protected	float		m_progress		= 0f;
	protected	Transform	m_transform;

	public		ParticleSystem				m_Emitting;
	#endregion

	// Use this for initialization
	void Start () 
	{
		m_currentIndex = 0;
		m_count = m_points.Length;
		m_transform = GetComponent<Transform>();
		GetNextPos(m_currentIndex );
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( m_Active )
			Animate();
		
	}

	void Animate( )
	{
		m_progress += m_speed / m_count * Time.deltaTime;
		//if( !m_Emitting.isPlaying )
		//	m_Emitting.Play();
		Debug.Log( m_currentIndex + " m_nextPos = " + m_nextPos );
	//	Debug.Log( m_currentIndex + " progress = " + m_progress );
		if( m_progress > 1f )
		{
			m_progress = 1 - m_progress;
		//	if( !m_Emitting.isPlaying )
		//		m_Emitting.Play();
			if( m_currentIndex > m_count - 2 )
			{
				m_currentIndex = 0;
				m_Active = false;
		//		if( m_Emitting.isPlaying )
		//			m_Emitting.Stop();
				return;
			}
			else
			{
				m_currentIndex++;
				GetNextPos(m_currentIndex );
			}

		}
		//m_transform.localPosition = Vector3.Lerp( m_points[m_currentIndex].localPosition, m_nextPos, m_progress );
		m_transform.localPosition = Vector3.Lerp( m_transform.localPosition, m_nextPos, m_progress );

	}

	void GetNextPos( int index )
	{
		m_nextPos = m_points[index].localPosition;
	}



}
