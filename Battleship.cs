using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectThreeBattleship
{
    class Battleship : Ship
    {
        public Battleship()
        {
            name = "Battleship";
            size = 4;
            sunk = false;
        }
        public override void SetCoordinates(List<string> coordinates)
        {
            this.coordinates = coordinates;
        }
    }
}
