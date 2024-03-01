using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface TurretInput
{
    void OnUpdate(Turret turret);
}

public class Turret : MonoBehaviour
{
    #region fields
    TurretInput _input;//игрок или АИ

    #endregion

    public void OnUpdate()
    {
        _input.OnUpdate(this);
    }

    public void RotationX()
    {

    }


    public void RotationZ()
    {

    }
}
