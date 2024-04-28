using UnityEditor;
using UnityEditor.EditorTools;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace True10
{

    [EditorTool("Snap", typeof(SnappedObject))]
    public class SnapTool : EditorTool
    {
        public Texture2D ToolIcon;

        private const float CHECK_DISTANCE = 1.5f;
        private SnappedObject[] _allSnappedObjects;
        private SnappedObject _oldTarget;
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

            EditorGUI.BeginChangeCheck();
            var newPos = Handles.PositionHandle(targetTransform.position, Quaternion.identity);

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(targetTransform, "Move with snap");
                targetTransform.position = newPos;
                MoveWithSnap(targetTransform, newPos);
            }
        }

        private void MoveWithSnap(Transform targetTransform, Vector3 position)
        {
            var targetSnappedObject = (SnappedObject)target;
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

        private bool TryToSnap(SnappedObject object1, SnappedObject object2)
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

        private bool TryToGetAllSnappedObjects(SnappedObject targetSnappedObject)
        {
            if (targetSnappedObject == _oldTarget)
            {
                return false;
            }
            _oldTarget = targetSnappedObject;
            PrefabStage prefabStage = PrefabStageUtility.GetPrefabStage(_oldTarget.gameObject);
            if (prefabStage != null)
            {
                _allSnappedObjects = prefabStage.prefabContentsRoot.GetComponentsInChildren<SnappedObject>();
            }
            else
            {
                _allSnappedObjects = FindObjectsOfType<SnappedObject>();
            }
            return true;
        }
    }
}
