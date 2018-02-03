using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    public interface IGameOfLifeService
    {

        bool[,] GetBoard();

        void NextGenerationBoard();

        void InitFirstGenerationBoard(uint width, uint height, List<Tuple<uint, uint>> livingCellsPosition);

    }
}
