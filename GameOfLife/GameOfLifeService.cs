using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    public class GameOfLifeService : IGameOfLifeService
    {
        private bool[,] board;

        public bool[,] GetBoard()
        {
            if (board == null) {
                return null;
            }

            bool[,] currentStateBoard = new bool[board.Length, board.GetLength(0)];

            for (var x = 0; x < board.GetLength(0); x++)
            {
                for (var y = 0; y < board.GetLength(1); y++)
                {
                    currentStateBoard[x, y] = board[x, y];
                }
            }

            return currentStateBoard;
        }

        public void InitFirstGenerationBoard(uint width, uint heigth, List<Tuple<uint, uint>> livingCellsPosition)
        {

            board = new bool[width, heigth];

            foreach (Tuple<uint, uint> tuple in livingCellsPosition)
            {
                if (tuple.Item1 > width || tuple.Item2 > heigth)
                {
                    throw new OutOfBoundPositionException();
                }
                board[tuple.Item1, tuple.Item2] = true;
            }
        }

        public void NextGenerationBoard()
        {
            if (board == null)
            {
                return;
            }

            bool[,] currentStateBoard = new bool[board.GetLength(0), board.GetLength(1)];

            for (var x = 0; x < board.GetLength(0); x++)
            {
                for (var y = 0; y < board.GetLength(1); y++)
                {
                    if(CountNeighbourAlive(x, y) < 2 || CountNeighbourAlive(x, y) > 3)
                    {
                        currentStateBoard[x, y] = false;
                    }
                    else if (CountNeighbourAlive(x, y) == 3)
                    {
                        currentStateBoard[x, y] = true;
                    }
                    else
                    {
                        currentStateBoard[x, y] = board[x, y];
                    }
                }
            }

            board = currentStateBoard;
        }

        private uint CountNeighbourAlive(int x, int y)
        {
            if (board == null)
            {
                throw new OutOfBoundPositionException();
            }

            var allPositions = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(x - 1, y - 1),
                new Tuple<int, int>(x, y -1),
                new Tuple<int, int>(x + 1, y - 1),
                new Tuple<int, int>(x - 1, y),
                new Tuple<int, int>(x + 1, y),
                new Tuple<int, int>(x - 1, y + 1),
                new Tuple<int, int>(x, y + 1),
                new Tuple<int, int>(x + 1, y + 1)
            };

            uint alive = 0;

            foreach (var position in allPositions)
            {
                if (ExistsAndIsAlive(position.Item1, position.Item2))
                {
                    alive++;
                }
            }

            return alive;
        }

        private bool ExistsAndIsAlive(int x, int y)
        {
            if (x < 0 || x > board.GetLength(0) - 1 || y <0 || y > board.GetLength(1) - 1)
            {
                return false;
            }

            return board[x, y];
        }

        public override string ToString()
        {
            StringBuilder boardString = new StringBuilder();

            for (var x = 0; x < board.GetLength(0); x++)
            {
                for (var y = 0; y < board.GetLength(1); y++)
                {
                    boardString.Append(board[x, y] ? "0" : "-");
                }
                boardString.Append(Environment.NewLine);
            }

            return boardString.ToString();
        }
    }
}