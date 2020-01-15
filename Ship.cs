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

        public bool sunk { get; set; }

        public abstract void SetCoordinates(List<string> coordinates);


    }
}
