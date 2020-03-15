namespace MarsRover
{
    public class East : Direction
    {

        public override Position MoveForward(Position currentPos)
        {
            Position newPos = new Position();
            newPos.xPosition = ++currentPos.xPosition;
            newPos.yPosition = currentPos.yPosition;

            return newPos;
        }

        public override char PrintID()
        {
            return 'E';
        }

        public override Direction RotateLeft()
        {
            return new North();
        }

        public override Direction RotateRight()
        {
            return new South();
        }
    }
}
