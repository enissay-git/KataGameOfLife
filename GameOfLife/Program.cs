using System;
using System.Collections.Generic;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Game of life!");

            var myGame = new GameOfLifeService();
            var livingCellPosition = new List<Tuple<uint, uint>>();

            livingCellPosition.Add(new Tuple<uint, uint>(3, 3));
            livingCellPosition.Add(new Tuple<uint, uint>(3, 4));
            livingCellPosition.Add(new Tuple<uint, uint>(5, 5));
            livingCellPosition.Add(new Tuple<uint, uint>(7, 8));
            livingCellPosition.Add(new Tuple<uint, uint>(7, 7));
            livingCellPosition.Add(new Tuple<uint, uint>(5, 6));
            livingCellPosition.Add(new Tuple<uint, uint>(5, 5));
            livingCellPosition.Add(new Tuple<uint, uint>(4, 7));
       


            myGame.InitFirstGenerationBoard(10, 10, livingCellPosition);

            for (var step = 1; step < 50; step++)
            {
                Console.WriteLine($"Game of life step {step}");
                Console.WriteLine(myGame.ToString());
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
                myGame.NextGenerationBoard();
            }

        }
    }
}
