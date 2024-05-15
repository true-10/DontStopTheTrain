using ModestTree;
using System.Linq;
using True10.LevelScrollSystem;
using UnityEditor;
using UnityEditor.EditorTools;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

namespace True10.Tools
{
    [EditorTool("Snap", typeof(SnappedObject))]
    public class SnapTool : EditorTool
    {
        public Texture2D ToolIcon;

        private const float CHECK_DISTANCE = 1.5f;
        private SnapPoint[] _allSnapPoints;
        private SnapPoint[] _targetSnapPoints;
        private Transform _oldTarget;
       
        private void OnEnable()
        {

        }

        public override GUIContent toolbarIcon
        {
            get
            {
                return new GUIContent()
                {
                    image = ToolIcon,
                    text = "Snap Tool",
                    tooltip = "Snapped object with points"
                };
            }
        }

        public override void OnToolGUI(EditorWindow window)
        {
            base.OnToolGUI(window);
            Transform targetTransform = ((SnappedObject)target).transform;

            TryToGetAllSnapPoints(targetTransform);

            EditorGUI.BeginChangeCheck();
            var newPos = Handles.PositionHandle(targetTransform.position, Quaternion.identity);

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(targetTransform, "Move with snap");
                targetTransform.position = newPos;
                TryToSnap(targetTransform, newPos);
            }
        }

        private bool TryToSnap(Transform targetTransform, Vector3 newPosition)
        {
            Vector3 bestPosition = newPosition;
            float closestDistance = float.PositiveInfinity;

            foreach (var point in _allSnapPoints)
            {
                foreach (var ownPoint in _targetSnapPoints)
                {
                    if (ownPoint.Type != point.Type)
                    {
                        continue;
                    }
                    var targetPos = point.transform.position - (ownPoint.transform.position - targetTransform.position);
                    float disctance = Vector3.Distance(targetPos, newPosition);
                    if(disctance < closestDistance)
                    {
                        bestPosition = targetPos;
                        closestDistance = disctance;
                    }
                }
            }

            if (closestDistance < CHECK_DISTANCE)
            {
                targetTransform.position = bestPosition;
                return true;
            }
            targetTransform.position = newPosition;
            return false;
        }

        private bool TryToGetAllSnapPoints(Transform targetTransform)
        {
            if (targetTransform == _oldTarget)
            {
                return false;
            }
            _oldTarget = targetTransform;
            _targetSnapPoints = ((SnappedObject)target).Points.ToArray();

            PrefabStage prefabStage = PrefabStageUtility.GetPrefabStage(_oldTarget.gameObject);
            if (prefabStage != null)
            {
                _allSnapPoints = prefabStage.prefabContentsRoot.GetComponentsInChildren<SnapPoint>()
                    .Except(_targetSnapPoints)
                    .ToArray();
            }
            else
            {
                _allSnapPoints = FindObjectsOfType<SnapPoint>()
                    .Except(_targetSnapPoints)
                    .ToArray();
            }
            return true;
        }
    }
}
