using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorWithMesh : MonoBehaviour
{
    #region Ui
    [SerializeField] private Mesh theMesh;
    [SerializeField] private Transform blocksRoot;
    [SerializeField] private GameObject blockPrefab;
    [SerializeField] private float theMeshScale = 1000f;
    [SerializeField] private float prefabScale = 1f;

    #endregion
    private List<GameObject> blocks = new List<GameObject>();

    List<Vector3> verts = new List<Vector3>();
    #region vars

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        Generate();


    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            StopAllCoroutines();
            Generate();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine( StartAmimation() );
        }

    }

    IEnumerator StartAmimation()
    {
        //if(verts == null ||)
        for (int i = 0; i < 10000; i++)
        {
            theMeshScale += Time.deltaTime * 5f;
            prefabScale += Time.deltaTime * 5f;
            yield return null;

            UpdateBlocks(verts);
            yield return null;
        }
        yield return null;

    }
    //TODO: ëåðïàòü ìåæäó âåðøèíàìè?
    //ÄÎÁÀÂÈÒÜ ÀÍÈÌÀÖÈÞ ÏÑÈÕÎÄÅËÈÊÀ ÄÎÊÒÎÐ ÑÒÐÅÉÍÄÆ ÁÀËÄÅÆ
    //äîáàâèòü èíôó â âåðøèíû, ÷òî áû íà îñíîâàíèè ýòîãî âûáèðàòü áëîê
    public void Generate()
    {
        ClearAll();
        verts.AddRange(theMesh.vertices);
        foreach (var v in verts)
        {
            Vector3 pos = theMeshScale * v + transform.position;
            GameObject newBlock = Instantiate(blockPrefab, pos, Quaternion.identity, blocksRoot);
            newBlock.transform.localScale = prefabScale * Vector3.one;
            blocks.Add(newBlock);
        }

        Debug.Log($"verts.Count = {verts.Count} blocks.Count = {blocks.Count}");


    }

    void ClearAll()
    {
        blocks.ForEach(x => DestroyImmediate(x));
        blocks.Clear();
        verts.Clear();
    }


    void UpdateBlocks(List<Vector3> verts)
    {
        for (int i = 0; i < verts.Count; i++)
        {
            Vector3 pos = theMeshScale * verts[i] + transform.position;
            GameObject block = blocks[i];
            block.transform.localPosition = pos;
            block.transform.localScale = prefabScale * Vector3.one;
        }
    }
}
