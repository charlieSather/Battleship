using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectThreeBattleship
{
    class AircraftCarrier : Ship
    {
        public AircraftCarrier()
        {
            name = "Aircraft Carrier";
            size = 5;
            sunk = false;
        }

        public override void SetCoordinates(List<string> coordinates)
        {
            this.coordinates = coordinates;
        }

    }
}
