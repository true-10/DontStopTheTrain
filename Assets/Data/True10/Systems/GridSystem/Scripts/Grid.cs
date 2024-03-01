using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace True10.GridSystem
{

    public enum GridType
    {
        Square = 0, //квадратные ячейки
        Hex,    //шестиугольник
    }

    public interface IGrid
    {
        Action<IGridCell> OnClick { get; set; }

        Vector3 CellSize { get; set; }
        Vector2Int gridSize { get; set; }
        List<IGridCell> Cells { get; }
        Bounds BoundSize { get; }

        GridType Type { get; }
        void GenerateGrid();
        IGridCell GetCellByPosition(Vector3 point);
    }

    public abstract class AbstractGrid : IGrid
    {

        #region callbacks
        public Action<IGridCell> OnClick { get; set; }
        #endregion
        public Vector3 CellSize { get; set; }
        public Vector2Int gridSize { get; set; }
        public abstract Bounds BoundSize { get; }
        public abstract List<IGridCell> Cells { get; }
        public abstract GridType Type { get; }
        public abstract void GenerateGrid();
        public abstract IGridCell GetCellByPosition(Vector3 point);
    }

    //какая разница хекс сетка или обычная? обычная + смещение четных/нечетных столбов
    //просто логика поиска пути другая? можно ходить по диагонали?
    public class GridHex : AbstractGrid
    {
        [SerializeField] float yOffset = 0.5f;
        public override GridType Type => GridType.Hex;

        #region callbacks; }
        public override List<IGridCell> Cells { get => gridCells; }
        public override Bounds BoundSize { get => bounds; }

        #endregion

        #region vars
        private List<IGridSector> sectors;
        private List<IGridCell> gridCells;
        private Bounds bounds;
        //size

        private Vector3 startPos = Vector3.zero;
        private Vector3 cellSize = Vector3.zero;
        private Vector2Int sectorSize = Vector2Int.one * 3;

        private Dictionary<int, List<IGridCell>> sectorsDictionary = new Dictionary<int, List<IGridCell>>();
        #endregion

        public GridHex(float yOffset, Vector2Int sectorSize, Vector3 cellSize)
        {
            gridCells = new List<IGridCell>();
            this.yOffset = yOffset;
            this.sectorSize = sectorSize;
            this.cellSize = cellSize;
        }

        public override void GenerateGrid()
        {
            gridCells.Clear();// ClearGrid();
            int index = 0;
            float xSize = CellSize.x;
            float ySize = CellSize.z;
            startPos.x = -gridSize.x / 2 * xSize;
            startPos.z = -gridSize.y / 2 * ySize;
            for (int z = 0; z < gridSize.y; z++)
            {
                for (int x = 0; x < gridSize.x; x++)
                {

                    Vector3 newPos = startPos + new Vector3(x * xSize + xSize, 0.0f, z * ySize + yOffset * (x % 2) * ySize);
                    GridCell cell = new GridCell(index, newPos, cellSize);
                    //cell.OnStart();
                    cell.LocalPosition = newPos;
                    cell.CalculateBounds();
                    gridCells.Add(cell);
                    index++;
                }
            }
            CalculateBounds();
            CalculateSectors();
          //  CalcNeighbours();
        }

        public override IGridCell GetCellByPosition(Vector3 point)
        {
            foreach (var sector in sectors)
            {
                var cell = sector.GetCellByPosition(point);
                if (cell != null)
                {
                    return cell;
                }
            }
            return null;
        }

        private void CalculateBounds()
        {
            var center = Vector3.zero;

            float xSize = CellSize.x;
            float ySize = CellSize.z;

            float w = gridSize.x * xSize;
            float l = gridSize.y * ySize;
            float h = 1f;
            var size = new Vector3(w, h, l);

            center.x = startPos.x + w / 2f;
            center.y = startPos.y;
            center.z = startPos.z + l / 2f;

            bounds = new Bounds(center, size);

        }

        private void CalculateSectors()
        {//по количеству клеток делать секторы? типа 2 на 2
            sectors = new List<IGridSector>();
            //Debug.Log($"CalculateSectors");
            int sectorIndex = 0;
            int sectorCellIndexX = 0;
            int sectorCellIndexY = 0;
            int sectorNumb = gridCells.Count / (sectorSize.x * sectorSize.y);
            Debug.Log($"sectorSize ={sectorSize} | gridSize={gridSize}");

            for (int i = 0; i < gridCells.Count; i++)
            {
                IGridCell cell = gridCells[i];
                int x = i % gridSize.x;
                int y = i / gridSize.x;

                sectorIndex = 0;
                int sectorX = x / sectorSize.x;
                int sectorY = y / sectorSize.y;

                sectorIndex = sectorX + sectorY * sectorSize.x;

                AddCellToSector(cell, sectorIndex);
               // Debug.Log($"i={i} | x={x} y={y} | sectorX={sectorX} sectorY={sectorY} | sectorIndex={sectorIndex}");

            }



            foreach (var s in sectorsDictionary)            
            {
                var sector = new GridSector(s.Value, s.Key, gridSize);
                
                sectors.Add(sector);
            }

        }

        private void AddCellToSector(IGridCell cell, int sectorIndex)
        {
            if (sectorsDictionary.ContainsKey(sectorIndex))
            {
                var sectorCells = sectorsDictionary[sectorIndex];
                sectorCells.Add(cell);
            }
            else
            {
                List<IGridCell> newSectorCells = new List<IGridCell>();
                newSectorCells.Add(cell);
                sectorsDictionary.Add(sectorIndex, newSectorCells);

            }
        }
    }


    public interface IGridSector : ICells
    {
        int Index { get; }
        Vector2Int GridSize{ get; }
        IGridCell GetCellByPosition(Vector3 point);
    }

    public class GridSector: IGridSector
    {
        public int Index { get; private set; }
        public Vector2Int GridSize { get; private set; }
        public List<IGridCell> Cells { get; set; }


        private Bounds bounds;//границы сектора

        public GridSector(List<IGridCell> cells, int index, Vector2Int gridSize)
        {
            this.Cells = cells;
            this.Index = index;
            this.GridSize = gridSize;
           // this.bounds = bounds;
            CalculateBounds();

        }
        public IGridCell GetCellByPosition(Vector3 point)
        {
            if (bounds.Contains(point))
            {
                foreach (var cell in Cells)
                {
                    if (cell.CheckPoint(point))
                    {
                        return cell;
                    }
                }
            }
            return null;
        }

        private void CalculateBounds()
        {
            
            Vector2 minBorder = Vector2.zero;
            Vector2 maxBorder = Vector2.zero;
            Vector3 center = Vector3.zero;
            Vector3 size = Vector3.one;
            if (Cells.Count == 0)
            {
                bounds = new Bounds(center, size);
                return;
            }
            var cellSize = Cells[0].Size;
            foreach (var cell in Cells)
            {
                center += cell.LocalPosition;
                Vector3 point = cell.LocalPosition + cell.Size / 2f;
                //cell.Size
                //cell.LocalPosition
            }
            center /= Cells.Count;
            size.x = GridSize.x * cellSize.x;
            size.y = cellSize.y;
            size.z = GridSize.y * cellSize.z;
            bounds = new Bounds(center, size);
        }
    }
}