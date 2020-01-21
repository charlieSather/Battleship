using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectThreeBattleship
{
    public static class StaticRandom
    {
        public static Random rand = new Random();

        public static int Next(int start, int end)
        {
            return rand.Next(start, end);
        }
        public static int Next(int end)
        {
            return rand.Next(end);
        }
        public static int NextInclusive(int start, int end)
        {
            return rand.Next(start, end + 1);
        }
        public static int NextInclusive(int end)
        {
            return rand.Next(end + 1);
        }
    }
}
