using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMultiGoal : CBaseGoal
{
	#region fields
		public		CBaseGoal[]		m_list;
	#endregion

	//сбрасываем до дефолта
	public override void Reset () 
	{
		for( int i = 0; i < m_list.Length; i++ )
		{
			m_list[i].Reset();
		}
	}

	// проверка выполненности цели
	public override bool IsReached () 
	{
		bool result = false;
		for( int i = 0; i < m_list.Length; i++ )
		{
			if( m_list[i].IsReached() ) 
			{
				result = true;
			}
			else
			{
				return false;	
			}
				
		}
		return result;	
	}

	//запускаем механизмы всякие
	public override void GoalStart()
	{
		for( int i = 0; i < m_list.Length; i++ )
		{
			m_list[i].GoalStart();
		}
	}
}
