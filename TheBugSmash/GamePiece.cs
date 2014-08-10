using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheBugSmash
{
    abstract class GamePiece
    {
        protected int x;
        protected int y;

        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }

        public GamePiece(int newX, int newY)
        {
            x = newX;
            y = newY;
        }
    }
}
