using System;

namespace Battleship
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var board = new Board();
            var game = new Game(board);
            game.Initialize();
            var turn = 1;
            while (true)
            {
                Console.WriteLine($"Turn: {turn}");
                board.PrintBoard();
                var input = Console.ReadLine();
                if (input != "Exit")
                {
                    var result = game.Shot(input);
                    Console.WriteLine(result);
                    if (result.Equals("Won!"))
                    {
                        break;
                    }
                    turn++;
                }
                else
                {
                    break;
                }
            }

            Console.ReadKey();
        }
    }
}