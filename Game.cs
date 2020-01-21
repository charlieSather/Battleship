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

            //SetupPlayers();
            //SetupPlayerBoards();

            AutomatedSetup();

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

            playerOne.DrawShips();
            playerTwo.DrawShips();
            

        }
        public void AutomateShipPlacement(Player player)
        {
            foreach(Ship ship in player.ships)
            {
                switch (ship.name)
                {
                    case ("Destroyer"):
                        ship.SetCoordinates(new List<string> { "A1", "A2" });
                        break;
                    case ("Submarine"):
                        ship.SetCoordinates(new List<string> { "B1", "B2","B3" });
                        break;
                    case ("Battleship"):
                        ship.SetCoordinates(new List<string> { "C1", "C2", "C3","C4" });
                        break;
                    case ("Aircraft Carrier"):
                        ship.SetCoordinates(new List<string> { "D1", "D2", "D3", "D4", "D5"});
                        break;
                }
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
