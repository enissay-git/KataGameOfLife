using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    public interface IGameOfLifeService
    {

        int CountLivingNeighbours (int row, int column);

        bool IsAlive(Cell myCell);

        Cell GetCell(int row, int column);

        void NextGenerationGrid();

        void InitFirstGenerationGrid(int heigth, int width, int[,] livingCellsPosition);

    }
}
