using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Button_InGame : MonoBehaviour
{
    #region fields
    [SerializeField, Range(0f, 1f)] private float _threshold;
    protected Transform _player;
    #endregion

    public abstract void PressButton();

    protected bool CheckUserDirection()
    {
        if (_player == null) return false;

        //проверяем смотрит ли игрок на кнопку
        if (Vector3.Dot(transform.forward, _player.forward) < -1f * _threshold)
            return true;

        return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        _player = other.transform;
        if(CheckUserDirection() )//если смотрим на кнопку
        {
            //если нажали нужную клавишу, то
            if (Input.GetButton("Use"))
            {
                PressButton();
            }
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        _player = null;
    }
}
