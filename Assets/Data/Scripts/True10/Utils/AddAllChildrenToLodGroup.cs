using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace True10.Utils
{

    public class AddAllChildrenToLodGroup : MonoBehaviour
    {
        [SerializeField]
        private LODGroup _lodGroup;

        [ContextMenu("AddAllChildrenToLodGroup0")]
        public void AddAllChildrenToLodGroup0()
        {
            Undo.RecordObject(_lodGroup.gameObject, "AddAllChildrenToLodGroup0");
            var lods = _lodGroup.GetLODs();
            var lod0 = lods[0];

            PrefabStage prefabStage = PrefabStageUtility.GetPrefabStage(_lodGroup.transform.parent.gameObject);
            Renderer[] _allRenderers = null;
            if (prefabStage != null)
            {
                _allRenderers = prefabStage.prefabContentsRoot.GetComponentsInChildren<Renderer>();
            }
            else
            {
                _allRenderers = GetComponentsInChildren<Renderer>();
              //  _allRenderers = FindObjectsOfType<Renderer>();
            }

            lod0.renderers = _allRenderers;
            lods[0] = lod0;
            _lodGroup.SetLODs(lods);
        }

    }
}
