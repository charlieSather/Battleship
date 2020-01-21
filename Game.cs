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
        bool gameOver;

        public void Run()
        {
            UserInterface.DisplayRules();

            int choice = UserInterface.PromptAutoFill();
            switch (choice)
            {
                case 1:
                    AutomatedSetup();
                    break;
                case 2:
                    SetupPlayers();
                    SetupPlayerBoards();
                    break;
            }

            gameOver = false;
            PlayGame();

            Console.ReadLine();
        }
        public void PlayGame()
        {
            while (PlayerAlive(playerOne) && PlayerAlive(playerTwo))
            {
                PlayTurn(playerOne, playerTwo);

                if (!PlayerAlive(playerTwo))
                {
                    break;
                }    
                
                PlayTurn(playerTwo, playerOne);
            }

            if (PlayerAlive(playerOne))
            {
                UserInterface.PrintWinner(playerOne);
            }
            else
            {
                UserInterface.PrintWinner(playerTwo);
            }
        }

        public void PlayTurn(Player player, Player targetPlayer)
        {
            player.opponentBoard.printBoard();
            string target = UserInterface.GetPlayersTarget(player);

            player.Fire(target, targetPlayer);
        }

        public void SetupPlayers()
        {
            playerOne = new Player(UserInterface.GetPlayersName());
            playerTwo = new Player(UserInterface.GetPlayersName());
        }
        public void SetupPlayerBoards()
        {           
            PlaceShips(playerOne);
            PlaceShips(playerTwo);
        }
        public void PlaceShips(Player player)
        {
            foreach(Ship ship in player.ships)
            {
                player.PlaceShip(ship);
            }
        }

        public void AutomatedSetup()
        {
            playerOne = new Player("Charlie");
            playerTwo = new Player("Greg");
            AutomateShipPlacement(playerOne);
            AutomateShipPlacement(playerTwo);
            playerOne.board.printBoard();
            playerOne.PrintShips();
            Console.WriteLine($"\n{playerOne.name}'s board and ships\nenter to see next player's board");
            Console.ReadLine();
            playerTwo.board.printBoard();
            playerTwo.PrintShips();
            Console.WriteLine($"\n{playerTwo.name}'s board and ships\nEnter to begin playing");
            Console.ReadLine();
        }

        public void AutomateShipPlacement(Player player)
        {
            foreach (Ship ship in player.ships)
            {
                player.board.drawShipRandomly(ship);
            }
        }

        public bool PlayerAlive(Player player)
        {
            bool alive = false;
            foreach(Ship ship in player.ships)
            {
                if (!ship.IsSunk())
                {
                    alive = true;
                    break;
                }
            }
            return alive;
        }

       

    }
}
