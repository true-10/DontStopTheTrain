using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using True10.Utils;

[CustomEditor(typeof(StaticDataSO))]
public class StaticDataInspector : Editor
{
    private StaticDataSO staticDataSO;


    private void OnEnable()
    {
        staticDataSO = (StaticDataSO)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();


        if (GUILayout.Button("LoadFromSheet"))
        {
            staticDataSO.LoadFromSheet();
        }
        GUILayout.Space(10);
    }

}
