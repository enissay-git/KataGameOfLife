using GameOfLife;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace GameOfLifeTest
{
    [TestClass]
    public class GameOfLifeTests
    {
        /*
         * 1. Any live cell with fewer than two live neighbours dies, as if caused by underpopulation.
         * 2. Any live cell with more than three live neighbours dies, as if by overcrowding.
         * 3. Any live cell with two or three live neighbours lives on to the next generation.
         * 4. Any dead cell with exactly three live neighbours becomes a live cell.
        */
        private IGameOfLifeService myInterface;

        private void InitTest ()
        {
            myInterface = null;
        }

        private void InitTest(int heigth, int width, List<Tuple<int, int>> livingCellsPosition)
        {
            InitTest();
            myInterface.InitFirstGenerationBoard(heigth, width, livingCellsPosition);
        }

        private bool ComparePositionWithListOfTuples (int x, int y, List<Tuple<int, int>> livingCellsPosition)
        {
            foreach (Tuple<int, int> tuple in livingCellsPosition)
            {
                if (tuple.Item1 == x && tuple.Item2 == y)
                {
                    return true;
                }
            }

            return false;
        }

        private bool CheckBoardWithListOfLivingCells (bool[,] board, List<Tuple<int, int>> livingCellsPosition)
        {
            for (var x = 0; x < board.Length ; x++)
            {
                for (var y = 0; y < board.GetLength(x); y++)
                {
                    if(board[x,y] != ComparePositionWithListOfTuples(x, y, livingCellsPosition))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        [TestMethod]
        public void when_cell_has_fewer_than_two_live_neighbours_then_this_cell_die()
        {
            var livingCeilPosition = new List<Tuple <int,int>> ();

            livingCeilPosition.Add(new Tuple<int, int>(0, 0));
            livingCeilPosition.Add(new Tuple<int, int>(0, 1));

            InitTest(5, 5, livingCeilPosition);
            myInterface.NextGenerationBoard();

            var newLivingCeilPosition = new List<Tuple<int, int>>();
            Assert.IsTrue(CheckBoardWithListOfLivingCells(myInterface.GetBoard(), newLivingCeilPosition));
        }

        [TestMethod]
        public void when_cell_has_more_than_three_live_neighbours_then_this_cell_die()
        {
            var livingCeilPosition = new List<Tuple<int, int>>();

            livingCeilPosition.Add(new Tuple<int, int>(0, 0));
            livingCeilPosition.Add(new Tuple<int, int>(0, 1));
            livingCeilPosition.Add(new Tuple<int, int>(0, 2));
            livingCeilPosition.Add(new Tuple<int, int>(1, 0));
            livingCeilPosition.Add(new Tuple<int, int>(1, 1));

            InitTest(5, 5, livingCeilPosition);
            myInterface.NextGenerationBoard();

            var newLivingCeilPosition = new List<Tuple<int, int>>();

            newLivingCeilPosition.Add(new Tuple<int, int>(0, 0));
            newLivingCeilPosition.Add(new Tuple<int, int>(0, 1));
            newLivingCeilPosition.Add(new Tuple<int, int>(0, 2));
            newLivingCeilPosition.Add(new Tuple<int, int>(1, 0));
            newLivingCeilPosition.Add(new Tuple<int, int>(1, 2));

            Assert.IsTrue(CheckBoardWithListOfLivingCells(myInterface.GetBoard(), newLivingCeilPosition));
        }

        [TestMethod]
        public void when_cell_has_exactly_three_live_neighbours_then_this_cell_stay_alive()
        {
            var livingCeilPosition = new List<Tuple<int, int>>();

            livingCeilPosition.Add(new Tuple<int, int>(0, 0));
            livingCeilPosition.Add(new Tuple<int, int>(0, 1));
            livingCeilPosition.Add(new Tuple<int, int>(0, 2));
            livingCeilPosition.Add(new Tuple<int, int>(1, 1));

            InitTest(5, 5, livingCeilPosition);
            myInterface.NextGenerationBoard();

            var newLivingCeilPosition = new List<Tuple<int, int>>();

            newLivingCeilPosition.Add(new Tuple<int, int>(0, 0));
            newLivingCeilPosition.Add(new Tuple<int, int>(0, 1));
            newLivingCeilPosition.Add(new Tuple<int, int>(0, 2));
            newLivingCeilPosition.Add(new Tuple<int, int>(1, 1));
            newLivingCeilPosition.Add(new Tuple<int, int>(1, 0));
            newLivingCeilPosition.Add(new Tuple<int, int>(1, 2));

            Assert.IsTrue(CheckBoardWithListOfLivingCells(myInterface.GetBoard(), newLivingCeilPosition));
        }

    }
}
