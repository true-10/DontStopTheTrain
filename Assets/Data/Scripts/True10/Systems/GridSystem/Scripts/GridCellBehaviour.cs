using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace True10.GridSystem
{
    public interface IGridCellBehaviour
    {
        Vector3 Size { get; set; }
        IGridCell GridCell { get; }
        void Construct(IGridCell gridCell);
      //  bool CheckPoint(Vector3 point);

    }

    [ExecuteInEditMode]
    public class GridCellBehaviour : MonoBehaviour, IGridCellBehaviour
    {
        #region events
        // [SerializeField] UnityEvent OnCellEnter;
        //[SerializeField] UnityEvent OnCellClick;
        #endregion

        #region fields
        [SerializeField] private Vector3 size = Vector3.one;
        [SerializeField] private float scale = 1f;
        [SerializeField] private bool gizmoOff = true;

        #endregion

        private IGridCell gridCell;

        public Vector3 Size { get => size; set => size = value; }
        public IGridCell GridCell { get => gridCell; }
        public float Scale { get => scale; set { scale = value; transform.localScale = Vector3.one * scale; } }


        private Bounds bounds;

        private void OnDrawGizmos()
        {
            if (gizmoOff) return;
            Gizmos.DrawCube(transform.position, size * Scale);
        }

        public void Construct(IGridCell gridCell)
        {
            this.gridCell = gridCell;

           // CalculateBounds();
            //gridCell.OnCellEnter
        }

        /*public bool CheckPoint(Vector3 point)
        {
            return gridCell.ch
            bool result = bounds.Contains(point);
            Debug.Log($"{name}::CheckPoint() bounds = {bounds} point = {point}  result = { result}");
            return result;
        }*/

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnCellClickHandler()
        {
          //  OnCellClick.Invoke();
        }
    }

}