using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectThreeBattleship
{
    class Player
    {
        public Board board { get; private set; }
        public Board opponentBoard { get; private set; }
        public List<Ship> ships { get; private set; }
        public string name { get; private set; }

        public Player(string name)
        {
            this.name = name;
            board = new Board();
            board.setupBoard();
            opponentBoard = new Board();
            opponentBoard.setupBoard();

            ships = new List<Ship>
            {
                new Destroyer(),
                new Submarine(),
                new Battleship(),
                new AircraftCarrier()
            };

        }

        public void PlaceShip(Ship ship)
        {
            List<(int,int)> coordinates = new List<(int,int)>();
            Console.WriteLine("Please enter");


        }


    }
}
