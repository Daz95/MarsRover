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

        public void Move(string function)
        {
            switch(function)
            {
                case "L":
                    CurrentLocation.direction = CurrentLocation.direction.RotateLeft();
                    break;
                case "R":
                    CurrentLocation.direction = CurrentLocation.direction.RotateRight();
                    break;
                case "M":
                    CurrentLocation.position = CurrentLocation.direction.MoveForward(CurrentLocation.position);
                    break;
                default:
                    throw new InvalidInputException("Invalid input! Please choose a correct function.");
            }
        }
        
        public Location GetLocation()
        {
            return CurrentLocation;
        }
        
        public static Position GetPosition(string xyPos)
        {
            string[] coordinates = xyPos.Split(" ");
            string errorMessage = "Incorrect X and Y input!";

            if (coordinates.Length != 2)
                throw new InvalidInputException(errorMessage);

            int x, y;
            if(Int32.TryParse(coordinates[0], out x) && Int32.TryParse(coordinates[1], out y))
                return new Position { xPosition = x, yPosition = y };

            throw new InvalidInputException(errorMessage);
        }     

    }
}
