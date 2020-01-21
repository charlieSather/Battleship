using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

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
            string input = "";
            bool validInput = false;
            while (validInput == false)
            {
                input = Console.ReadLine();
                if (input == "")
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

                    if (CoordinateExists(input,player.board))
                    {
                        if (!player.ShipsHaveCoordinate(input))
                        {
                            validInput = true;
                        }
                    }
                }
                coordinates.Add(input);
                validInput = false;
            }
            return coordinates;
        }
        public static bool CoordinateExists(string coordinate, Board board)
        {
            if (board.map.ContainsKey(coordinate))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Coordinate does not exist. Please try again");
                return false;
            }
        }

        public static void ShipHasCoordinate(Player player, Ship ship, string coordinate)
        {
            Console.WriteLine($"Sorry {player.name}! But your {ship.name} is already placed at {coordinate}");
            Console.WriteLine("Please enter a different coordinate.");
        }

        public static string GetPlayersTarget(Player player)
        {
            Console.Clear();
            player.opponentBoard.printBoard();
            Console.WriteLine($"{player.name} please select a location to fire");
            string input = "";
            bool validInput = false;

            while(validInput == false)
            {
                input = Console.ReadLine();
                if(CoordinateExists(input, player.opponentBoard))
                {
                    if(player.opponentBoard.TileIsEmpty(input))
                    {
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine($"You've already fired there {player.name}, enter another coordinate");
                    }
                }
            }
            return input;
        }
        public static void HitShip(Player player, string coordinate)
        {
            Console.Clear();
            player.opponentBoard.printBoard();
            Console.WriteLine($"{player.name}'s landed a hit at {coordinate}!!!");
            Console.WriteLine("Press enter to end turn");
            Console.ReadLine();
        }
        public static void SunkShip(Player player, Ship ship)
        {
            //Console.Clear();
            Console.WriteLine($"\n{player.name}'s {ship.name} has sunk!!!");
            Console.WriteLine("Press enter to end turn");
            Console.ReadLine();
        }
        public static void MissedShip(Player player, string coordinate)
        {
            Console.Clear();
            player.opponentBoard.printBoard();
            Console.WriteLine($"{player.name}'s shot has missed at {coordinate}!");
            Console.WriteLine("Press enter to end turn");
            Console.ReadLine();
        }
        public static void PrintWinner(Player player)
        {
            player.opponentBoard.printBoard();
            Console.WriteLine($"Congratulations {player.name}!!");
            Console.WriteLine($"You have won the game!!!!");
            Console.ReadLine();
        }

        public static int PromptAutoFill()
        {
            Console.Clear();
            Console.WriteLine("Select Game Mode:\n1: Automated with completely random but unique guessing\n2: Automated random ship placement with player guessing\n3: Standard gameplay");

            Regex intMatch = new Regex(@"^[1,2,3]$");
            string input = Console.ReadLine();
            if (intMatch.IsMatch(input))
            {
                return Int32.Parse(input);
            }
            else
            {
                Console.WriteLine("Try Again");
                return PromptAutoFill();
            }
        }


    }
    }
