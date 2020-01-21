using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectThreeBattleship
{
    abstract class Ship
    {
        public int size { get; set; }
        public List<string> coordinates { get; set; }
        public string name { get; set; }
        public int hitsReceived { get; private set; }

        public bool sunk { get; set; }

        public void AddCoordinate(string coordinate)
        {
            coordinates.Add(coordinate);
        }
        public void SetCoordinates(List<string> coordinates)
        {
            this.coordinates = coordinates;
        }   

        public bool HasCoordinate(string coordinate)
        {
            return coordinates.Contains(coordinate);
        }
        public void Hit()
        {
            hitsReceived++;
        }

        public bool IsSunk()
        {
            return hitsReceived == size ? true : false;
        }

        public override string ToString()
        {
            string coords = $"{name}";

            foreach(string coord in coordinates)
            {
                coords += ", " + coord;
            }
            return coords;
        }





    }
}
