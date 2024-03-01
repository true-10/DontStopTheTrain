using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace True10.GridSystem
{
    public interface IGridObject
    {

    }

    public interface ICells
    {
        List<IGridCell> Cells { get; }
    }

    public interface IGridCell
    {
        //Action OnCellClick { get; set; }
        int Index { get; }
        Vector3 LocalPosition { get; set; }
        Vector3 WorldPosition { get; set; }
        Vector3 Size { get; set; }
        IGridObject GridObject { get; set; }
        bool CheckPoint(Vector3 point);
        void CalculateBounds();
        // IVehicleController VehicleController { get; set; } перенести в наследника.
        // это что бы кликать по сетке, а не колайдеры юнитов. нашли клетку, там кто то есть? наш? чужой? ходить атаковать
        //только ли тачку хранить? GridObject?
    }

    public class GridCell : IGridCell
    {
        #region callbacks
        public Action<int> OnCellEnter { get; set; }
        public Action<int> OnCellExit { get; set; }
        public Action<int> OnCellOver { get; set; }
        public Action<int> OnCellClick { get; set; }
        public Action<int> OnCellRelease { get; set; }
        public Action<int> OnCellHold { get; set; }
        #endregion


        #region properties
        public int Index { get; }
        public Vector3 LocalPosition { get; set; }
        public Vector3 WorldPosition { get; set; }
        public Vector3 Size { get; set; }
        public Vector3Int Position { get; }
        public IGridObject GridObject { get; set; }
        #endregion
        #region vars
        private Bounds bounds;
        #endregion

        public GridCell(int index, Vector3Int position)
        {
            Index = index;
            Position = position;
        }

        public GridCell(int index, Vector3 position, Vector3 size)
        {
            Index = index;
            Size = size;
            Position = new Vector3Int( (int)position.x, (int)position.y, (int)position.z) ;
          //  CalculateBounds();
        }

        public void CalculateBounds()
        {
            var center = LocalPosition;
            bounds = new Bounds(center, Size);

        }

        public bool CheckPoint(Vector3 point)
        {
            bool result = bounds.Contains(point);
            //Debug.Log($"GridCell::CheckPoint() bounds = {bounds} point = {point}  result = { result}");
            return result;
        }

    }
}