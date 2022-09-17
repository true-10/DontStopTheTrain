using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GTime //: MonoBehaviour
{
    #region fields

    public static float gTimeScale = 1f;
    public static float gDeltaTime
    {
        get
        {
            return Time.deltaTime * gTimeScale;
        }
    }
    public static float gFixedDeltaTime
    {
        get
        {
            return Time.fixedDeltaTime * gTimeScale;
        }
    }
    public static float gUnscaledDeltaTime
    {
        get { return Time.deltaTime;  }
    }

    #endregion
}
