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
            UserInterface.DisplayRules();

            SetupPlayers();
            SetupPlayerBoards();


            Console.ReadLine();
        }

        public void SetupPlayers()
        {
            playerOne = new Player(UserInterface.GetPlayersName());
            playerTwo = new Player(UserInterface.GetPlayersName());
        }
        public void SetupPlayerBoards()
        {
            playerOne.board.initMap();
            playerOne.board.setupBoard();
            PlaceShips(playerOne);

            playerTwo.board.initMap();
            playerTwo.board.setupBoard();
            PlaceShips(playerTwo);

        }
        public void PlaceShips(Player player)
        {
            foreach(Ship ship in player.ships)
            {
                player.PlaceShip(ship);
            }
        }

    }
}
