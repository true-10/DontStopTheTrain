using System;

namespace True10.GridSystem
{

    public interface IGridGenerator
    {
        IGrid GenerateGrid();
    }

    public class GridGenerator : IGridGenerator
    {

        public IGrid GenerateGrid()
        {
            return null;
        }
    }
}
