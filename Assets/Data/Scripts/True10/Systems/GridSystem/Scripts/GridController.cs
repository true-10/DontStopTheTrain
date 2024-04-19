using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace True10.GridSystem
{
    public interface IGridController
    {
        IGrid Grid { get; }
    }

    public class GridController : IGridController
    {
        private GridHex grid;
        public IGrid Grid
        {
            get
            {
                return grid;
            }
        }

    }
}