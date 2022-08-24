using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainGUI : MonoBehaviour
{
    #region fields
    private Locomotiv _loco;
    [SerializeField] private Text _speedText;
    #endregion

    public void OnUpdate()
    {
        _speedText.text = "Speed: " + Mathf.Round( _loco.GetSpeed() ).ToString();
    }

    public void SetLoco(Locomotiv loco)
    {
        _loco = loco;
    }
}
