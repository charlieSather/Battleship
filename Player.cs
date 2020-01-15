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
            List<string> coordinates = new List<string>();

            Console.WriteLine($"Please enter {ship.size} coordinates to place your {ship.name}");
            string input = "";
            bool validInput = false;

            for(int i = 0; i < ship.size; i++)
            {
                while(validInput == false)
                {
                    input = Console.ReadLine();

                    if (board.map.ContainsKey(input) == true)
                    {
                        validInput = IsCoordinateAvailable(input, ship);
                        {
                            if(validInput == false)
                            {
                                Console.WriteLine("\nAnother ship is currently occupying that coordinate please select another");
                            }
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
            ship.SetCoordinates(coordinates);
            board.DrawShip(ship);
            coordinates.Clear();
        }

        public bool IsCoordinateAvailable(string coordinate,Ship ship)
        {
            bool availableCoordinate = true;

            foreach(Ship currentShip in ships)
            {
                //problematic line if we want to add more ships in future
                if(currentShip.name == ship.name)
                {
                    continue;
                }
                if(currentShip.HasCoordinate(coordinate) == true)
                {
                    availableCoordinate = false;
                }
            }
            return availableCoordinate;
        }

       


    }
}
