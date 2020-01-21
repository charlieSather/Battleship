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
        int gameMode;

        List<string> allCoordsOne;
        List<string> allCoordsTwo;

        public void Run()
        {
            Console.SetWindowSize(75,35);

            UserInterface.DisplayRules();

            gameMode = UserInterface.PromptAutoFill();
            switch (gameMode)
            {
                case 1:
                    AutomatedSetup();
                    break;
                case 2:
                    AutomatedSetup();
                    break;
                case 3:
                    SetupPlayers();
                    SetupPlayerBoards();
                    break;
            }
            PlayGame();

            Console.ReadLine();
        }
        public void PlayGame()
        {
            if(gameMode == 1)
            {
                allCoordsOne = new List<string>();
                allCoordsOne.AddRange(playerOne.board.map.Keys);

                allCoordsTwo = new List<string>();
                allCoordsTwo.AddRange(playerTwo.board.map.Keys);
            }
                  
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

            if(gameMode == 1)
            {
                if(player.name == playerOne.name)
                {
                    string target = player.board.GetRandomCoordinate(allCoordsOne);
                    player.Fire(target, targetPlayer);
                }
                else
                {
                    string target = player.board.GetRandomCoordinate(allCoordsTwo);
                    player.Fire(target, targetPlayer);
                }

            }
            else
            {
                player.opponentBoard.printBoard();
                string target = UserInterface.GetPlayersTarget(player);
                player.Fire(target, targetPlayer);
            }
         
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
            foreach (Ship ship in player.ships)
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
            foreach (Ship ship in player.ships)
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
