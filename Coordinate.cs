using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectThreeBattleship
{
    class Coordinate
    {
        public string letter { get; private set; }
        public int indexOne { get; private set; }
        public int indexTwo { get; private set; }

        public Coordinate(string letter, int indexOne, int indexTwo)
        {
            this.letter = letter;
            this.indexOne = indexOne;
            this.indexTwo = indexTwo;
        }        

    }
}
