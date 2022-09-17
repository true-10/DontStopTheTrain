using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationChunk : LayerChunk
{
    #region fields
    [SerializeField] private StationStopTrigger _stationTrigger;
    #endregion
   

    public void ActivateTrigger(bool active)
    {
        _stationTrigger.Activate(active);
    }
}
