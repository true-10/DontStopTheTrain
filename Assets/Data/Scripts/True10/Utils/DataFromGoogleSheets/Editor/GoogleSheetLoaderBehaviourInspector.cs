using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using True10.Utils;


[CustomEditor(typeof(GoogleSheetLoaderBehaviour))]
public class GoogleSheetLoaderBehaviourInspector : Editor
{
    private GoogleSheetLoaderBehaviour googleSheetLoader;

    private void OnEnable()
    {
        googleSheetLoader = (GoogleSheetLoaderBehaviour)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();


        if (GUILayout.Button("LoadFromSheet"))
        {
           // googleSheetLoader.LoadFromSheet();
        }
        GUILayout.Space(10);
    }
}
