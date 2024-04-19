using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace True10.DayLightSystem
{

    [CreateAssetMenu(fileName = "DaylightSettings", menuName = "True10/DaylightSettings")]
    public class DayLightSettingsScriptableObject : ScriptableObject
    {
        public DayLightSettings data;
    }
}
