using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectThreeBattleship
{
    class Destroyer : Ship
    {
        public Destroyer()
        {
            name = "Destroyer";
            size = 2;
        }

        public override void SetCoordinates(List<int> coordinates)
        {
            this.coordinates = coordinates;
        }
    }
}
