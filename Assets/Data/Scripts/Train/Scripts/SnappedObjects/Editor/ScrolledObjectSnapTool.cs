using True10.LevelScrollSystem;
using UnityEditor;
using UnityEditor.EditorTools;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace True10.Tools
{

    [EditorTool("Snap Scrolled Object", typeof(ScrolledObject))]
    public class ScrolledObjectSnapTool : EditorTool
    {
        public Texture2D ToolIcon;

        private const float CHECK_DISTANCE = 1.5f;
        private ScrolledObject[] _allSnappedObjects;
        private ScrolledObject _oldTarget;

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
                    text = "Snap Tool for scrolled objects",
                    tooltip = "Snapped scrolled object with points"
                };
            }
        }

        public override void OnToolGUI(EditorWindow window)
        {
            base.OnToolGUI(window);
            Transform targetTransform = ((ScrolledObject)target).transform;

            EditorGUI.BeginChangeCheck();
            var newPos = Handles.PositionHandle(targetTransform.position, Quaternion.identity);

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(targetTransform, "Move scrolled object with snap");
                targetTransform.position = newPos;
                MoveWithSnap(targetTransform, newPos);
            }
        }

        private void MoveWithSnap(Transform targetTransform, Vector3 position)
        {
            var targetSnappedObject = (ScrolledObject)target;
            TryToGetAllSnappedObjects(targetSnappedObject);
            foreach (var snappedObject in _allSnappedObjects)
            {
                if (snappedObject == targetSnappedObject)
                {
                    continue;
                }
                if (TryToSnap(targetSnappedObject, snappedObject))
                {
                    return;
                }
            }
        }

        private bool TryToSnap(ScrolledObject object1, ScrolledObject object2)
        {
            if(IsCloseDistance(object1.StartPoint.position, object2.EndPoint.position))
            {
                object1.AlignmentWithStartPoint(object2.EndPoint);
                return true;
            }
            else
            if (IsCloseDistance(object1.EndPoint.position, object2.StartPoint.position))
            {
                object1.AlignmentWithEndPoint(object2.StartPoint);
                return true;
            }
            return false;
        }

        private bool IsCloseDistance(Vector3 point1, Vector3 point2)
        {
            float disctance = Vector3.Distance(point1, point2);
            if (disctance < CHECK_DISTANCE)
            {
                return true;
            }
            return false;
        }      

        private bool TryToGetAllSnappedObjects(ScrolledObject targetSnappedObject)
        {
            if (targetSnappedObject == _oldTarget)
            {
                return false;
            }
            _oldTarget = targetSnappedObject;
            PrefabStage prefabStage = PrefabStageUtility.GetPrefabStage(_oldTarget.gameObject);
            if (prefabStage != null)
            {
                _allSnappedObjects = prefabStage.prefabContentsRoot.GetComponentsInChildren<ScrolledObject>();
            }
            else
            {
                _allSnappedObjects = FindObjectsOfType<ScrolledObject>();
            }
            return true;
        }
    }
}
