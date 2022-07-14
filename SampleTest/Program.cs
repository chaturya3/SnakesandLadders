using System;
using System.Collections.Generic;

namespace SnakesandLadders
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ladders

            (int, int)[] ladders = {
            (2, 38), (7, 14), (8, 31), (16, 26), (21, 42),
            (28, 84), (36, 44), (51, 67), (71, 91), (78, 98), (87, 94)
        };
            // Snakes
            (int, int)[] snakes = {
            (15, 5), (48, 10), (45, 24), (61, 18), (63, 59),
            (73, 52), (88, 67), (91, 87), (94, 74), (98, 79)
        };
            // Board by default.
            var board = new Board(10, 10, ladders, snakes);
            var players = new List<Player>();
            int numPlayers;
            do
            {
                Console.Write("Enter the number of players: ");
                numPlayers = Convert.ToInt32(Console.ReadLine());

                if (numPlayers <= 1)
                {
                    Console.WriteLine("The total of players need to be 2 or more.");
                }
            } while (numPlayers <= 1);

            for (int i = 1; i <= numPlayers; i++)
            {
                Console.Write($"Enter the name for the player {i}: ");
                string nickName = Console.ReadLine();

                players.Add(new Player(nickName, board));
            }
            char pressed;
            int count = 0;
            do
            {
                Player currentPlayer = players[count];
                Console.WriteLine($"It's the player {currentPlayer.NickName}'s turn");
                Console.WriteLine("Press R to Roll the dice or A to abort the game.");
                pressed = Char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();

                if (pressed == 'R')
                {
                    Console.WriteLine("--------------------------------");

                    currentPlayer.Roll();
                    Console.WriteLine($"Dice's result: {currentPlayer.DiceResult} ");

                    int previousPosition = currentPlayer.Position;
                    currentPlayer.Move();
                    Console.WriteLine($"{currentPlayer.NickName} moved from cell [{previousPosition}] ====> to cell [{currentPlayer.Position}]");

                    if (currentPlayer.Winner)
                    {
                        Console.WriteLine($"Player {currentPlayer.NickName} won the game.");
                        break;
                    }

                    Console.WriteLine("--------------------------------");
                    count = (count + 1) % numPlayers;
                }
            } while (pressed != 'A');
        }
    }
}

