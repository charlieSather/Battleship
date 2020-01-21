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
            opponentBoard = new Board();

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
            List<string> coordinates = UserInterface.GetStartEndCoordinates(this, ship);

            (string, string) startEnd = (coordinates[0], coordinates[1]);

            if(board.CanDraw(ship, coordinates))
            {
                board.DrawShip(ship, startEnd);
            }
            else
            {
                Console.WriteLine("Couldn't place ship");
                PlaceShip(ship);
            }
        }

        public void Fire(string target,Player opponent)
        {
            if (opponent.Hit(target))
            {
                opponentBoard.DrawHit(target);
                UserInterface.HitShip(this, target);
            }
            else
            {
                opponentBoard.DrawMiss(target);
                UserInterface.MissedShip(this, target);
            }            
        }

        public bool Hit(string coordinate)
        {
            bool hit = false;

            foreach(Ship ship in ships)
            {
                if (ship.HasCoordinate(coordinate))
                {
                    ship.Hit();
                    hit = true;
                    if (ship.IsSunk())
                    {
                        UserInterface.SunkShip(this, ship);
                    }
                }
            }
            return hit;
        }
        public bool ShipsHaveCoordinate(string coordinate)
        {
            bool coordinateExists = false;
            foreach(Ship ship in ships)
            {
                if (ship.HasCoordinate(coordinate))
                {
                    UserInterface.ShipHasCoordinate(this, ship, coordinate);
                    coordinateExists = true;
                    break;
                }
            }
            return coordinateExists;
        }
        public void DrawShips()
        {
            foreach(Ship ship in ships)
            {
                (string, string) startEnd = (ship.coordinates[0], ship.coordinates[ship.coordinates.Count - 1]);
                board.DrawShip(ship, startEnd);
            }
        }
    }
}
