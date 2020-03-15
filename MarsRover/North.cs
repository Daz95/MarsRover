namespace MarsRover
{
    public class North : Direction
    {

        public override Position MoveForward(Position currentPos)
        {
            Position newPos = new Position();
            newPos.xPosition = currentPos.xPosition;
            newPos.yPosition = ++currentPos.yPosition;

            return newPos;
        }

        public override char PrintID()
        {
            return 'N';
        }

        public override Direction RotateLeft()
        {
            return new West();
        }

        public override Direction RotateRight()
        {
            return new East();
        }
    }
}
