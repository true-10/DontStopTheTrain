using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StationPlayerGUI : MonoBehaviour
{
    #region fields
    private Player _player;
    [SerializeField] private Text _levelText;
    [SerializeField] private Text _expoText;
    [SerializeField] private Text _creditText;
    [SerializeField] private Text _AOText;//action points
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void UpdateGUI()
    {
        _levelText.text = "Level: " + _player._level.ToString();
        _expoText.text = "Expo: " + Mathf.Round( _player._expo ).ToString();
        _creditText.text = "Credits: " + _player._credits.ToString();
        _AOText.text = "Action Points: " + _player._actionPoints.ToString();
    }


    public void SetPlayerRef(ref Player player)
    {
        _player = player;
    }
}
