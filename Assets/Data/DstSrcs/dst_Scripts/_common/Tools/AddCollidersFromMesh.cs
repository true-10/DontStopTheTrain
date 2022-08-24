using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCollidersFromMesh : MonoBehaviour
{
    #region fields
    public bool m_NotThisRoot = true; //если скрипт на корне коллайдеров
    
    [NaughtyAttributes.ShowIf("m_NotThisRoot")]
    public GameObject m_root;

    BoxCollider[] m_boxColliders;
    BoxCollider[] m_rootBoxColliders;
    Transform[] m_transforms;

    #endregion
    [NaughtyAttributes.Button(" Generate Colliders on Chidren")]
    void GenerateColliders()
    {
        if (!m_NotThisRoot) m_root = transform.gameObject;
        MeshRenderer[] renderers = m_root.GetComponentsInChildren<MeshRenderer>();
        int count = renderers.Length;

        m_transforms = new Transform[count];
        m_boxColliders = new BoxCollider[count];
        for (int i = 0; i < count; i++)
        {
            m_transforms[i] = renderers[i].transform;

            m_boxColliders[i] = m_transforms[i].gameObject.AddComponent<BoxCollider>();
            m_boxColliders[i].size = renderers[i].bounds.size;
            renderers[i].enabled = false;
            //m_boxColliders[i]. = renderers[i].bounds.extents;
        }

    }

    [NaughtyAttributes.Button("Generate Colliders On Root") ]
    void GenerateCollidersOnRoot()
    { //а если дети были повернуты?
        if (m_boxColliders == null) return;
        int count = m_transforms.Length;
        m_rootBoxColliders = new BoxCollider[count];
        for (int i = 0; i < count; i++)
        {
            m_rootBoxColliders[i] =  m_root.AddComponent<BoxCollider>();
            m_rootBoxColliders[i].size = m_boxColliders[i].size;
            m_rootBoxColliders[i].center = m_transforms[i].localPosition;

        }
    }

    [NaughtyAttributes.Button("Remove Chidrens Colliders")]
    void RemoveChidrensColliders()
    {
        if (m_boxColliders == null) return;

        int count = m_boxColliders.Length;
        for (int i = 0; i < count; i++)
        {
            DestroyImmediate(m_boxColliders[i]);
        }
        m_boxColliders = null;
    }

    [NaughtyAttributes.Button("Remove Roots Colliders")]
    void RemoveRootColliders()
    {
        if (m_rootBoxColliders == null) return;
       
        int count = m_rootBoxColliders.Length;
        for (int i = 0; i < count; i++)
        {
            DestroyImmediate(m_rootBoxColliders[i]);
        }
        m_rootBoxColliders = null;
    }

    [NaughtyAttributes.Button("Remove MeshRenderers")]
    void RemoveMeshRenderers()
    {
      /*  if (m_rootBoxColliders == null) return;

        int count = m_rootBoxColliders.Length;
        for (int i = 0; i < count; i++)
        {
            DestroyImmediate(m_rootBoxColliders[i]);
        }
        m_rootBoxColliders = null;
        */
    }
}
