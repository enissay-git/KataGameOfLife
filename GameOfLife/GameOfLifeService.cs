using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    class GameOfLifeService : IGameOfLifeService
    {
        public bool[,] GetBoard()
        {
            throw new NotImplementedException();
        }

        public void InitFirstGenerationBoard(int heigth, int width, List<Tuple<int, int>> livingCellsPosition)
        {
            throw new NotImplementedException();
        }

        public void NextGenerationBoard()
        {
            throw new NotImplementedException();
        }
    }
}