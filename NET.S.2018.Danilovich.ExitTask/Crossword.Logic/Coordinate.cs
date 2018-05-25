using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossword.Logic
{
    public class Coordinate
    {
        public int CoordX { get; set; }
        public int CoordY { get; set; }

        public Coordinate(int x, int y)
        {
            CoordX = x;
            CoordY = y;
        }
    }
}
