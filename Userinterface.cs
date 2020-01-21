using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectThreeBattleship
{
    static class UserInterface
    {
        public static void DisplayRules()
        {
            Console.WriteLine("Welcome to battleship! you know the rules already!");
        }
        public static string GetPlayersName()
        {
            Console.WriteLine("\nPlease enter a name for player");
            string input  = "";
            bool validInput = false;
            while(validInput == false)
            {
                input = Console.ReadLine();
                if(input == "")
                {
                    Console.WriteLine("\nNo empty names here!!!");
                }
                else
                {
                    Console.WriteLine($"\nWelcome {input}!");
                    validInput = true;
                }                
            }
            return input;
        }

        public static List<string> GetStartEndCoordinates(Player player, Ship ship)
        {
            List<string> coordinates = new List<string>();
            Console.Clear();
            player.board.printBoard();

            Console.WriteLine($"{player.name}, Please enter starting coordinate and ending coordinate to place your {ship.name}");
            string input = "";
            bool validInput = false;

            for (int i = 0; i < 2; i++)
            {
                while (validInput == false)
                {
                    input = Console.ReadLine();

                    if (player.board.map.ContainsKey(input) == true)
                    {
                        if (!player.ShipsHaveCoordinate(input))
                        {
                            validInput = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Coordinate does not exist. Please try again");
                    }
                }
                coordinates.Add(input);
                validInput = false;
            }
            return coordinates;
        }

        public static void ShipHasCoordinate(Player player, Ship ship, string coordinate)
        {
            Console.WriteLine($"Sorry {player.name}! But your {ship.name} is already placed at {coordinate}");
            Console.WriteLine("Please another coordinate.");
        }


    }
}
