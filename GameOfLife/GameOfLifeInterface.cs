using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    interface GameOfLifeInterface
    {

        int CountLivingNeighbours (int row, int column);

        bool IsAlive(int row, int column);

        void NextGenerationGrid();

        void InitFirstGenerationGrid(int heigth, int width, int[,] livingCellsPosition);

    }
}
