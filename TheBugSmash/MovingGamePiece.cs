using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheBugSmash
{
   abstract class MovingGamePiece : GamePiece
    {
        protected int direction;
        public int Direction
        {
            get { return direction; }
            set
            {
                if (value >= 0 && value <= 3)
                    direction = value;
            }
        }
        public MovingGamePiece(int x, int y, int dir)
			: base(x, y)
		{
			// Use the property to set the direction
			Direction = dir;
		}
    }
}

