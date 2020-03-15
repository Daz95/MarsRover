using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public abstract class Direction
    {
        public abstract Position MoveForward(Position currentPos);

        public abstract char PrintID();

        public abstract Direction RotateRight();
        public abstract Direction RotateLeft();
    }
}
