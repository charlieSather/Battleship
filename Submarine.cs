using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectThreeBattleship
{
    class Submarine : Ship
    {
        public Submarine()
        {
            name = "Submarine";
            size = 3;
        }
        public override void SetCoordinates(List<int> coordinates)
        {
            this.coordinates = coordinates;
        }
    }
}
