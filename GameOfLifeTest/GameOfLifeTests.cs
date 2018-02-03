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

        private void InitTest(uint width, uint height, List<Tuple<uint, uint>> livingCellsPosition)
        {
            InitTest();
            myInterface.InitFirstGenerationBoard(width, height, livingCellsPosition);
        }

        private bool ComparePositionWithListOfTuples (int x, int y, List<Tuple<uint, uint>> livingCellsPosition)
        {
            foreach (Tuple<uint, uint> tuple in livingCellsPosition)
            {
                if (tuple.Item1 == x && tuple.Item2 == y)
                {
                    return true;
                }
            }

            return false;
        }

        private bool CheckBoardWithListOfLivingCells (bool[,] board, List<Tuple<uint, uint>> livingCellsPosition)
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
        public void when_alive_cell_has_fewer_than_two_live_neighbours_then_this_cell_die()
        {
            var livingCellPosition = new List<Tuple <uint, uint>> ();

            livingCellPosition.Add(new Tuple<uint, uint>(0, 0));
            livingCellPosition.Add(new Tuple<uint, uint>(0, 1));

            InitTest(5, 5, livingCellPosition);
            myInterface.NextGenerationBoard();

            var newLivingCellPosition = new List<Tuple<uint, uint>>();
            Assert.IsTrue(CheckBoardWithListOfLivingCells(myInterface.GetBoard(), newLivingCellPosition));
        }

        [TestMethod]
        public void when_alive_cell_has_more_than_three_live_neighbours_then_this_cell_die()
        {
            var livingCellPosition = new List<Tuple<uint, uint>>();

            livingCellPosition.Add(new Tuple<uint, uint>(0, 0));
            livingCellPosition.Add(new Tuple<uint, uint>(0, 1));
            livingCellPosition.Add(new Tuple<uint, uint>(0, 2));
            livingCellPosition.Add(new Tuple<uint, uint>(1, 0));
            livingCellPosition.Add(new Tuple<uint, uint>(1, 1));

            InitTest(5, 5, livingCellPosition);
            myInterface.NextGenerationBoard();

            var newLivingCellPosition = new List<Tuple<uint, uint>>();

            newLivingCellPosition.Add(new Tuple<uint, uint>(0, 0));
            newLivingCellPosition.Add(new Tuple<uint, uint>(0, 1));
            newLivingCellPosition.Add(new Tuple<uint, uint>(0, 2));
            newLivingCellPosition.Add(new Tuple<uint, uint>(1, 0));
            newLivingCellPosition.Add(new Tuple<uint, uint>(1, 2));

            Assert.IsTrue(CheckBoardWithListOfLivingCells(myInterface.GetBoard(), newLivingCellPosition));
        }

        [TestMethod]
        public void when_alive_cell_has_exactly_three_live_neighbours_then_this_cell_stay_alive()
        {
            var livingCellPosition = new List<Tuple<uint, uint>>();

            livingCellPosition.Add(new Tuple<uint, uint>(0, 0));
            livingCellPosition.Add(new Tuple<uint, uint>(0, 1));
            livingCellPosition.Add(new Tuple<uint, uint>(0, 2));
            livingCellPosition.Add(new Tuple<uint, uint>(1, 1));

            InitTest(5, 5, livingCellPosition);
            myInterface.NextGenerationBoard();

            var newLivingCellPosition = new List<Tuple<uint, uint>>();

            newLivingCellPosition.Add(new Tuple<uint, uint>(0, 0));
            newLivingCellPosition.Add(new Tuple<uint, uint>(0, 1));
            newLivingCellPosition.Add(new Tuple<uint, uint>(0, 2));
            newLivingCellPosition.Add(new Tuple<uint, uint>(1, 1));
            newLivingCellPosition.Add(new Tuple<uint, uint>(1, 0));
            newLivingCellPosition.Add(new Tuple<uint, uint>(1, 2));

            Assert.IsTrue(CheckBoardWithListOfLivingCells(myInterface.GetBoard(), newLivingCellPosition));
        }

        [TestMethod]
        public void when_alive_cell_has_exactly_two_live_neighbours_then_this_cell_stay_alive()
        {
            var livingCellPosition = new List<Tuple<uint, uint>>();

            livingCellPosition.Add(new Tuple<uint, uint>(0, 0));
            livingCellPosition.Add(new Tuple<uint, uint>(0, 2));
            livingCellPosition.Add(new Tuple<uint, uint>(1, 1));

            InitTest(5, 5, livingCellPosition);
            myInterface.NextGenerationBoard();

            var newLivingCellPosition = new List<Tuple<uint, uint>>();

            newLivingCellPosition.Add(new Tuple<uint, uint>(0, 1));
            newLivingCellPosition.Add(new Tuple<uint, uint>(1, 1));

            Assert.IsTrue(CheckBoardWithListOfLivingCells(myInterface.GetBoard(), newLivingCellPosition));
        }

        [TestMethod]
        public void when_dead_cell_has_exactly_three_live_neighbours_then_this_cell_become_alive()
        {
            var livingCellPosition = new List<Tuple<uint, uint>>();

            livingCellPosition.Add(new Tuple<uint, uint>(0, 1));
            livingCellPosition.Add(new Tuple<uint, uint>(1, 0));
            livingCellPosition.Add(new Tuple<uint, uint>(1, 1));

            InitTest(5, 5, livingCellPosition);
            myInterface.NextGenerationBoard();

            var newLivingCellPosition = new List<Tuple<uint, uint>>();

            newLivingCellPosition.Add(new Tuple<uint, uint>(0, 0));
            newLivingCellPosition.Add(new Tuple<uint, uint>(0, 1));
            newLivingCellPosition.Add(new Tuple<uint, uint>(1, 0));
            newLivingCellPosition.Add(new Tuple<uint, uint>(1, 1));

            Assert.IsTrue(CheckBoardWithListOfLivingCells(myInterface.GetBoard(), newLivingCellPosition));
        }

        [TestMethod]
        public void when_init_board_with_width_and_height_at_zero_then_no_error()
        {
            var livingCellPosition = new List<Tuple<uint, uint>>();
            InitTest(0, 0, livingCellPosition);

            myInterface.NextGenerationBoard();

            Assert.IsNotNull(myInterface.GetBoard());
        }

        [TestMethod]
        public void when_init_board_with_living_cells_out_of_bound_then_detect_error_of_impossible_position()
        {
            var livingCellPosition = new List<Tuple<uint, uint>>();

            livingCellPosition.Add(new Tuple<uint, uint>(0, 6));

            Assert.ThrowsException<OutOfBoundPositionException>(() => InitTest(5, 5, livingCellPosition));
        }



    }
}
