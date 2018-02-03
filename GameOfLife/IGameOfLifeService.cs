using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    public interface IGameOfLifeService
    {

        bool[,] GetBoard();

        void NextGenerationBoard();

        void InitFirstGenerationBoard(int heigth, int width, List<Tuple<int,int>> livingCellsPosition);

    }
}
