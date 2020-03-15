namespace MarsRover
{
    public class South : Direction
    {

        public override Position MoveForward(Position currentPos)
        {
            Position newPos = new Position();
            newPos.xPosition = currentPos.xPosition;
            newPos.yPosition = --currentPos.yPosition;

            return newPos;
        }

        public override char PrintID()
        {
            return 'S';
        }

        public override Direction RotateLeft()
        {
            return new East();
        }

        public override Direction RotateRight()
        {
            return new West();
        }
    }
}
