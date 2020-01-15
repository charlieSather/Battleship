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
        }
        public override void SetCoordinates(List<int> coordinates)
        {
            this.coordinates = coordinates;
        }
    }
}
