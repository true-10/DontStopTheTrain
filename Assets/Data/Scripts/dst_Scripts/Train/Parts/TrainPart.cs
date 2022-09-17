using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//вагон как рама
//контейнер на раму: грузовой, пассажирский
public class TrainPart : MonoBehaviour
{
    #region fields
    [SerializeField] private TrainPartData _data;//данные о запчасти
    [SerializeField] private float _deterioration;//износ //износ
    //условие износа (типа нельзя нагружать много или ехать быстро)
    private float _deteriorations_speed;//множитель износа
    public bool _isBroken { get; private set; } = false;

    #endregion

    protected virtual void CalculationOfDeteriorationsSpeed()
    {

    }

    public virtual void UpdateDeterioration()
    {
        if (!_isBroken) return;
        _deterioration -= _deteriorations_speed * Time.deltaTime;
        if (_deterioration < 0.0f)
        {
            _isBroken = true;
            _deterioration = 0.0f;
        }
    }

    public void Repair()
    {
        _deterioration = _data._deterioration;
        _isBroken = false;
    }
}
