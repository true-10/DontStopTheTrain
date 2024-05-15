using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace DontStopTheTrain.Train.Editor
{

    [ExecuteAlways]
    public class TrainDebugger : EditorWindow
    {
        [MenuItem("DST/Train Debugger")]
        private static void OpenWindow()
        {
            var window = GetWindow<TrainDebugger>();

        }

        private void OnGUI()
        {
            
        }
    }

}
