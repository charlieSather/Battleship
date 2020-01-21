using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectThreeBattleship
{
    class Game
    {
        Player playerOne;
        Player playerTwo;
        Player player = new Player("Charlie");


        public void Run()
        {
            Board board = new Board();
            board.setupBoard();
            board.printBoard();
            player.board.initMap();
            player.SetupShips();
            Console.WriteLine(player.ships);

           // player.PlaceShip(player.ships[0]);


           // foreach (Ship boat in player.ships)
            //{
             //   player.PlaceShip(boat);
            //}
            //board.printBoard();

            // DisplayRules();
            // SetupPlayers();
            // SetupPlayerBoards();
            Ship ship = new Battleship();

            //   ship.SetCoordinates(new List<string> { "B10", "B11", "B12", "B13" });
            //  board.DrawShip(ship);
            player.board.printBoard();
            //board.printBoard();

           // Console.WriteLine(player.board.DoCoordinatesLink("A1", "5", new Battleship())); 


          //  playerOne.board.printBoard();

            Console.ReadLine();
        }

        public void DisplayRules()
        {
            Console.WriteLine("Welcome to battleship! you know the rules already!");
        }
        public void SetupPlayers()
        {
            playerOne = new Player(PromptPlayerName());
            playerTwo = new Player(PromptPlayerName());
        }
        public void SetupPlayerBoards()
        {
           

        }

        public string PromptPlayerName()
        {
            Console.WriteLine("\nPlease enter a name for player");
            string input = Console.ReadLine();
            switch (input)
            {
                case (""):
                    Console.WriteLine("\nNo empty names here!!!");
                    PromptPlayerName();
                    break;
                default:
                    break;
            }
            Console.WriteLine($"\nWelcome {input}!");
            return input;
        }

    }
}
