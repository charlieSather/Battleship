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


        public void Run()
        {
            Player player = new Player("Charlie");
            Board board = new Board();
            board.setupBoard();
            board.printBoard();

            DisplayRules();
            SetupPlayers();
            SetupPlayerBoards();

            playerOne.board.printBoard();

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
            playerOne.board.setupBoard();
            playerOne.opponentBoard.setupBoard();
            playerTwo.board.setupBoard();
            playerTwo.opponentBoard.setupBoard();

        }

        public string PromptPlayerName()
        {
            Console.WriteLine("Please enter a name for player");
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
