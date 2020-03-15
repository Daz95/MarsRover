namespace MarsRover
{
    public class West : Direction
    {

        public override Position MoveForward(Position currentPos)
        {
            Position newPos = new Position();
            newPos.xPosition = --currentPos.xPosition;
            newPos.yPosition = currentPos.yPosition;

            return newPos;
        }

        public override char PrintID()
        {
            return 'W';
        }

        public override Direction RotateLeft()
        {
            return new South();
        }

        public override Direction RotateRight()
        {
            return new North();
        }
    }
}
