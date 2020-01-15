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
        public string name { get; private set; }

        public Player(string name)
        {
            this.name = name;
            board = new Board();
            opponentBoard = new Board();
        }


    }
}
