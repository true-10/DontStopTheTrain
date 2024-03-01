using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace True10.GridSystem
{
    //вынести это
    public static class GlobalConstants
    {
        public static class LayersName
        {
            public const string GRID_LAYER = "Grid";
        }
    }

    //сетка доступная для тачки
    public interface ILocalGrid : ICells
    {

        /// <summary>
        /// получаем сетку в заданной точки с заданой длиной. определяется скоростью и маневринностью. экшн с расчетом вместо просто длины?
        /// </summary>
        /// <param name="index">индекс точки в списке ячеек сетки</param>
        /// <param name="length">длина сетки</param>
        void SetOnPoint(int index, int length);//получаем сетку для данной точки 
    }

    public class GridBehaviour : MonoBehaviour
    {
        #region injections
        [Zenject.Inject] private CameraSystem.ICameraController cameraController;
        #endregion

        #region refs
        [Header("Gizmos")]
        [SerializeField] private bool gizmoOn = true;
        [SerializeField] private Mesh gizmoMesh;
        [SerializeField] private GridCellBehaviour cellReference;
        [SerializeField] private Quaternion gizmoRotation;
        [SerializeField] private Vector3 offset;
       // [SerializeField] private Vector3 startPos;
        [Header("Prefabs")]
        [SerializeField] private GridCellBehaviour cellPrefab;
        [SerializeField] private Transform cellsRoot;
        [Header("Grid Data")]
        [SerializeField] private Vector2Int gridSize = Vector2Int.one * 5;
        [SerializeField] private Vector2Int sectorSize = Vector2Int.one * 3;
        [SerializeField] private float spacing = 1f;
        [SerializeField] private float yOffset = 0.5f;
        [Header("Collision")]
        [SerializeField] private BoxCollider gridCollider;//через него считаем кула попали

        [Header("TEST")]
        [SerializeField] private Transform clickPositionObject;
        [SerializeField] private Transform testObj;

        #endregion

        private float Spacing { get => spacing * cellReference.Scale; }
        private Vector3 cellSize { get => cellReference.Size; }// * cellReference.Scale; }

        #region vars
        private GridHex grid = null;
        //private List<IGridCell> cells;
        private List<GridCellBehaviour> cellsBehaviors = new List<GridCellBehaviour>();


        protected Vector3 mousePos;

        protected Camera cam;
        protected Ray ray;
        private Vector3 startPos = Vector3.zero;
        #endregion

        private void OnDrawGizmos()
        {
            if (gizmoOn == false) return;
            if (cellReference == null && gizmoMesh == null)
            {
                Debug.Log("cellReference == null");
                return;
            }

            Gizmos.color = Color.black;
            Vector3 size = cellReference.Size * cellReference.Scale;

            startPos.x = -gridSize.x / 2 * size.x;
            startPos.z = -gridSize.y / 2 * size.z;
            //grid.GenerateGrid();
            //cellReference.Size
            //отрисовка сетки в редакторе
            for (int z = 0; z < gridSize.y; z++)
            {
                for (int x = 0; x < gridSize.x; x++)
                {
                    var xPos = x * size.x  + size.x;
                    var zPos = z * size.z + yOffset * (x % 2) * size.z;
                    Vector3 center = transform.position + startPos + new Vector3(xPos, 0.0f, zPos);
                    Gizmos.DrawWireMesh(gizmoMesh, center + offset, gizmoRotation, cellReference.Scale * Vector3.one);
                    //  Gizmos.DrawWireCube(center, size);
                }
            }

        }


        void Start()
        {
            grid = new GridHex(yOffset, sectorSize, cellSize);
            grid.CellSize = cellSize;
            grid.gridSize = gridSize;
            grid.GenerateGrid();
            GenerateGrid();
            gridCollider.size = grid.BoundSize.size * cellReference.Scale;
            gridCollider.center = grid.BoundSize.center * cellReference.Scale;
            cam = Camera.main;
        }

        bool isNorm = false;
        // Update is called once per frame
        void Update()
        {
            RaycastHit hit;
            mousePos = Input.mousePosition;

            //это все надо в другой класс
            ray = cam.ScreenPointToRay(mousePos);
            var distance = 1200f;
            if (Physics.Raycast(ray, out hit, distance, 1 << LayerMask.NameToLayer(GlobalConstants.LayersName.GRID_LAYER)))
            {
                Vector3 point = hit.point;
                //кликаем по коллайдеру и высчитываем ячейку
                if (Input.GetMouseButtonDown(0))
                {
                     point.y = -0.5f;
                    //Debug.Log($"point = { point} ");
                    var cell = grid.GetCellByPosition(point);
                    if (cell != null)
                    {
                        testObj.position = cell.LocalPosition;
                        Debug.Log($"point = { point} cell.Index = {cell.Index}");
                    }    
                }
            }

            if(Input.GetKeyDown(KeyCode.C))
            {
                isNorm = !isNorm;
                if (isNorm)
                {
                    Time.timeScale = 1f;
                }
                else
                {
                    Time.timeScale = .1f;
                }
            }

        }

        public void GenerateGrid()
        {
            ClearGrid();
            foreach (var gridCell in grid.Cells)
            {
                var cell = Instantiate(cellPrefab, Vector3.zero, Quaternion.identity, cellsRoot);
                cell.transform.localPosition = gridCell.LocalPosition * cellReference.Scale;
                cell.Construct(gridCell);
                cell.name = cellPrefab.name + "_" + gridCell.Index.ToString();
                cellsBehaviors.Add(cell);
            }
            //CalcNeighbours();
        }

        private void ClearGrid()
        {
            cellsBehaviors.ForEach(x => Destroy(x.gameObject));
            cellsBehaviors.Clear();
        }

      
       // public void OnClick(Vector3 pos)
        public void OnClick(IGridCell gridCell)
        {
            //находим из списка ячейку куда тыкнули
            //если находим, то вызываем онКлик

        }
    }
}