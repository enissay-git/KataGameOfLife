using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    class GameOfLifeService : IGameOfLifeService
    {
        public int CountLivingNeighbours(int row, int column)
        {
            throw new NotImplementedException();
        }

        public Cell GetCell(int row, int column)
        {
            throw new NotImplementedException();
        }

        public void InitFirstGenerationGrid(int heigth, int width, int[,] livingCellsPosition)
        {
            throw new NotImplementedException();
        }

        public bool IsAlive(Cell myCell)
        {
            throw new NotImplementedException();
        }

        public void NextGenerationGrid()
        {
            throw new NotImplementedException();
        }
    }
}