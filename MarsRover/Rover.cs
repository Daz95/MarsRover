using System;

namespace MarsRover
{
    class Rover
    {
        private Location CurrentLocation;

        public Rover(Position position, Direction direction)
        {
            CurrentLocation = new Location
            {
                position = position,
                direction = direction
            };
        }

        public void Move(string functions, Position endofPlatau)
        {
            foreach(char function in functions)
            {
                switch (function)
                {
                    case 'L':
                        CurrentLocation.direction = CurrentLocation.direction.RotateLeft();
                        break;
                    case 'R':
                        CurrentLocation.direction = CurrentLocation.direction.RotateRight();
                        break;
                    case 'M':
                        CurrentLocation.position = MoveForward(endofPlatau);
                        break;
                    default:
                        throw new InvalidInputException("Invalid input! Please choose a correct function.");
                }
            }
        }

        private Position MoveForward(Position endofPlatau)
        {
            Position newPos =  CurrentLocation.direction.MoveForward(CurrentLocation.position);
            if (newPos.xPosition > endofPlatau.xPosition)
                newPos.xPosition = endofPlatau.xPosition;
            if (newPos.yPosition > endofPlatau.yPosition)
                newPos.yPosition = endofPlatau.yPosition;
            if (newPos.xPosition < 0)
                newPos.xPosition = 0;
            if (newPos.yPosition < 0)
                newPos.yPosition = 0;

            return newPos;
        }
        
        public Location GetLocation()
        {
            return CurrentLocation;
        }
          

    }
}
