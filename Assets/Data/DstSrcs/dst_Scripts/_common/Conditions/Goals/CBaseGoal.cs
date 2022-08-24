using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBaseGoal : MonoBehaviour 
{
	#region fields

	#endregion

	//сбрасываем до дефолта
	public virtual void Reset () 
	{
		
	}
	
	// проверка выполненности цели
	public virtual bool IsReached () 
	{
		//return true;
		return false;	
	}

	//запускаем механизмы всякие
	public virtual void GoalStart()
	{

	}

}
