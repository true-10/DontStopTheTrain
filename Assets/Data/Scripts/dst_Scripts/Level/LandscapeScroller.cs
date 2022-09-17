using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class LandscapeScroller : MonoBehaviour
{
    #region fields
    public static LandscapeScroller Singleton;//для управления скоростью как минимум
                                              // LandscapeLayer _battleLayer; //
    float _speedMult = 1f;//множитель
    [SerializeField]private List<LandscapeLayer> _layers; //все слои

    private Locomotiv _locomotiv;
    #endregion

    private void Awake()
    {
        if (LandscapeScroller.Singleton == null)
        {
            Singleton = this;
        }
        else Destroy(gameObject);
        Debug.Log("LandscapeScroller.Singleton = " + name);



    }

    //в трейнменеджер отправить?
    private void LateUpdate()
    {
        foreach (LandscapeLayer layer in _layers)
        {
            layer.OnLateUpdate();
        }
    }

    public float GetSpeed() => _locomotiv.GetSpeed();



    public void SetLoco(Locomotiv loco)
    {
        _locomotiv = loco;
    }
}
