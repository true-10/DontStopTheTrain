using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using True10.Utils;


[CustomEditor(typeof(GoogleSheetLoader))]
public class GoogleSheetLoaderInspector : Editor
{
    private GoogleSheetLoader googleSheetLoader;

    private void OnEnable()
    {
        googleSheetLoader = (GoogleSheetLoader)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();


        if (GUILayout.Button("LoadFromSheet"))
        {
            googleSheetLoader.LoadFromSheet();
        }
        GUILayout.Space(10);
    }
}
