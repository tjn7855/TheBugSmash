using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheBugSmash
{
    class Bug : MovingGamePiece
    {
        public int movement, turn, turn2;
        Random random = new Random(Guid.NewGuid().GetHashCode());

        public Bug(int x, int y, int dir)
            : base(x, y, dir)
        {
        }
        public bool Move()
        {
            if (this.Y >= 410 && this.x <= 118)
            {
                return true;
            }
            else
            {
                if ((this.Y < 50 && this.Y <= 430) && (this.X >= 50 && this.X <= 750))
                {
                    //hits top of screen
                    this.Direction = 2;
                }
                else if ((this.Y >= 50 && this.Y > 430) && (this.X >= 50 && this.X <= 750))
                {
                    //hits bottom of screen
                    this.Direction = 0;
                }
                else if ((this.Y >= 50 && this.Y <= 430) && (this.X < 50 && this.X <= 750))
                {
                    //hits left of screen
                    this.Direction = 1;
                }
                else if ((this.Y >= 50 && this.Y <= 430) && (this.X >= 50 && this.X > 750))
                {
                    //hits right of screen
                    this.Direction = 3;
                }
                else if ((this.Y < 50 && this.Y <= 430) && (this.X < 50 && this.X <= 750))
                {
                    //top left corner
                    this.Direction = random.Next(1, 3);
                }
                else if ((this.Y < 50 && this.Y <= 430) && (this.X >= 50 && this.X > 750))
                {
                    //top right corner
                    this.Direction = random.Next(2, 3);
                }
                else if ((this.Y >= 50 && this.Y > 430) && (this.X < 50 && this.X <= 750))
                {
                    //bottom left corner
                    this.Direction = random.Next(0, 2);
                }
                else if ((this.Y >= 50 && this.Y > 430) && (this.X >= 50 && this.X > 750))
                {
                    //bottom right corner
                    this.turn2 = random.Next(0, 2);
                    switch (this.turn2)
                    {
                        case 0: this.Direction = 0; break;
                        case 1: this.Direction = 3; break;
                    }
                }
                else if ((this.Y >= 50 && this.Y <= 430) && (this.X >= 50 && this.X <= 750))
                {
                    this.turn = random.Next(0, 2);
                    switch (turn)
                    {
                        case 0: this.Direction = this.Direction; break;
                        case 1: this.Direction = random.Next(0, 4); break;
                    }
                }
                movement = random.Next(0, 20);
                switch (direction)
                {
                    case 0: y -= movement; break;
                    case 1: x += movement; break;
                    case 2: y += movement; break;
                    case 3: x -= movement; break;
                }
                return false;
            }
        }
    }
}

