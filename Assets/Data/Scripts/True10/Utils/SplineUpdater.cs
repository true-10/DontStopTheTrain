using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;

namespace True10.Utils
{
    public class SplineUpdater : MonoBehaviour
    {
        public Action OnUpdate { get; set; }
        public SplineContainer SplineContainer => _splineContainer;

        [SerializeField]
        private SplineContainer _splineContainer;
        [SerializeField]
        private List<Transform> _path;

        private Transform _cachedTransform;
        // Start is called before the first frame update
        void Start()
        {
            _cachedTransform = GetComponent<Transform>();
            CreateSplineWithTransforms(_path);
        }

        // Update is called once per frame
        void Update()
        {
            UpdateSplineWithTransforms(_path);
        }

        public void CreateSplineWithTransforms(List<Transform> path)
        {
            var knots = new BezierKnot[path.Count];

            for (int i = 0; i < path.Count; i++)
            {
                knots[i] = new BezierKnot(path[i].position - _cachedTransform.position);
            }
            _splineContainer.Spline.Knots = knots;
        }


        public void UpdateSplineWithTransforms(List<Transform> path)
        {
            for (int i = 0; i < path.Count; i++)
            {
                /*var tangentIn = new float3();
                var tangentOut = new float3();
                if (i > 0 && i < path.Count - 1)
                {
                    tangentIn = path[i - 1].forward;
                }
                if (i < path.Count - 2)
                {
                    tangentOut = path[i + 1].forward;
                }
                var knot = new BezierKnot(path[i].position - _cachedTransform.position, tangentIn, tangentOut);*/
                var knot = new BezierKnot(path[i].position);// - _cachedTransform.position);
                knot.Rotation = path[i].rotation;
                _splineContainer.Spline.SetKnot(i, knot);
            }
            OnUpdate?.Invoke();
        }
    }
}
