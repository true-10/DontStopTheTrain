using System.Collections;
using System.Collections.Generic;
using True10.SplinesHelper;
using UnityEngine;
using UnityEngine.Splines;

public class TrainRigBehaviour : MonoBehaviour
{
    [SerializeField]
    protected SplineServiceBehaviour splineServiceBehaviour;
    [SerializeField]
    protected EngineBehaviour engine;
    [SerializeField]
    protected List<WagonRigBehaviour> WagonRigs;

     void Start()
    {
        UpdateWagonsRigsPositions();
        //  RecalculatePositions();
    }


    private void LateUpdate()
    {
        UpdateWagonsRigsPositions();
    }


    [ContextMenu("UpdateWagonsRigsPositions")]
    private void UpdateWagonsRigsPositions()
    {
        for (int i = 0; i < WagonRigs.Count; i++)
        {
            var wagonRig = WagonRigs[i];
            if (wagonRig.gameObject.activeInHierarchy == false)
            {
                continue;
            }
            UpdateWagonRigPos(wagonRig);
        }
    }

    private void UpdateWagonRigPos(WagonRigBehaviour wagonRig)
    {
        if (splineServiceBehaviour.TryToGetTransformDataFrom(wagonRig.WagonTransform.position, out var newPos, out var quaternion, out var t))
        {
            wagonRig.UpdateRig(newPos, quaternion);
            //  wagonRig.UpdateAxlesTransforms(OnGetAxelTransform);
        }
    }

    private void OnGetAxelTransform(Vector3 defaultPos, Transform axelTransform)
    {
        if (splineServiceBehaviour.TryToGetTransformDataFrom(defaultPos, out var newPos, out var quaternion, out var t))
        {
            axelTransform.position = newPos;
            axelTransform.rotation = quaternion;
        }
    }
    /*
        [ContextMenu("Set Wagons on Track")]
        private void SetWagonsOnTrack()
        {
            for (int i = 0; i < WagonRigs.Count; i++)
            {
                var wagonRig = WagonRigs[i];
                float distance = wagonRig.Length + wagonRig.Length * i;
                var t = splineServiceBehaviour.GetTFromDistance(distance);
                splineServiceBehaviour.Evaluate(t, out var newPos, out var quaternion, out var dist);

                wagonRig.UpdateRig(newPos, quaternion);
            }
}

[ContextMenu("Set Wagons in line")]
    private void SetWagonsInLine()
    {
        //float t = 0f;
        float distance = 0f;
        var wagonRig = WagonRigs[0];
        if (splineServiceBehaviour.TryToGetTransformDataFrom(wagonRig.WagonTransform.position, out var newPos, out var quaternion, out var t))
        {
            wagonRig.UpdateRig(newPos, quaternion);

            distance = splineServiceBehaviour.GetDistance(t);
            distance -= wagonRig.Length;
        }
        for (int i = 1; i < WagonRigs.Count; i++)
        {
            wagonRig = WagonRigs[i];
            t = splineServiceBehaviour.GetTFromDistance(distance);
            splineServiceBehaviour.Evaluate(t, out newPos, out quaternion, out var dist);

            wagonRig.UpdateRig(newPos, quaternion);
            distance -= wagonRig.Length;
        }  
    }

    
    private void LerpUpdateWagonsRigsPositions()
    {
        WagonRigs.ForEach(wagonRig =>
        {
            wagonRig.LerpToTargetTransform();
        });
    }
    

    int currentWagonIndex = 0;


    private void UpdateWagonsRigsPositionsPerFrame()
    {
        var wagonRig = WagonRigs[currentWagonIndex];
        UpdateWagonRigPos(wagonRig);
        currentWagonIndex++;
        if (currentWagonIndex > WagonRigs.Count-1)
        {
            currentWagonIndex = 0;
        }
    }
      
      */
}
