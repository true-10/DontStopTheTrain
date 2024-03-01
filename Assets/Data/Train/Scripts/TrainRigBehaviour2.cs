using System.Collections.Generic;
using UnityEngine;
//track editor!
//train editor
//wagon editor

[ExecuteInEditMode]
public class TrainRigBehaviour2 : MonoBehaviour
{
    [SerializeField]
    protected SplineServiceBehaviour splineServiceBehaviour;
    [SerializeField]
    protected BasicPhysicsSimulation basicPhysicsSimulation;
    [SerializeField]
    protected EngineBehaviour engine;
    [SerializeField]
    protected List<WagonRigBehaviour> WagonRigs; 
    
    void Start()
    {
        UpdateWagonsRigsPositions();
    }

    private void Update()
    {
        if (Application.isPlaying)
        {
            basicPhysicsSimulation.Simulate();
        }

        UpdateWagonsRigsPositions();
    }

    [ContextMenu("UpdateWagonsRigsPositions")]
    private void UpdateWagonsRigsPositions()
    {
        int prevRigIndex = -1;
        for (int i = 0; i < WagonRigs.Count; i++)
        {
            var wagonRig = WagonRigs[i];
            if (wagonRig.gameObject.activeInHierarchy == false)
            {
                continue;
            }
            Vector3 fromPosition = wagonRig.WagonTransform.position;
            if (prevRigIndex != -1)
            {
                var prevRig = WagonRigs[prevRigIndex];

            }
            if (splineServiceBehaviour.TryToGetTransformDataFrom(fromPosition, out var newPos, out var quaternion, out var t))
            {
                wagonRig.UpdateRig(newPos, quaternion);
                //  wagonRig.UpdateAxlesTransforms(OnGetAxelTransform);
            }
            prevRigIndex = i;
        }
    }
}
