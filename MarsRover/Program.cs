using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            Position endOfPlatau = init();
            
            while ((Console.ReadLine()) != "exit")
            {
                newRover(endOfPlatau);
                Console.WriteLine("Hit any key to create a new rover!");
            }
        }

        static Position init()
        {
            try 
            {
                Console.WriteLine("Tell me the size of the platau: X Y");
                Position endOfPlatau = GetPosition(Console.ReadLine());

                Console.WriteLine("Enter any key to build a new rover! Or type 'exit' to leave!");

                return endOfPlatau;
            }
            catch(InvalidInputException ex)
            {
                Console.WriteLine(ex.Message);
                return init();
            }

        }

        static void newRover(Position EndOfPlatau)
        {
            try 
            {
                Console.WriteLine("Let's see where you want to start! Input your starting coordinates (X and Y) and direction (D) to face: 'X Y D'");
                Console.WriteLine("Directions (D) to choose from: 'N', 'E', 'S' or 'W'!\n");
                string input = Console.ReadLine();
                if (input.Length != 5)
                    throw new InvalidInputException("Invalid starting position!");

                Position startPos = GetPosition(new string(input.ToCharArray(0, 3)));
                Direction startDir = GetDirection(input[4]);

                Rover newRover = new Rover(startPos, startDir);
                PrintCurrentLocation(newRover);

                Console.WriteLine("\nJust type 'exit' at any time to leave!");

                play(newRover, EndOfPlatau);
            }

            catch(InvalidInputException ex)
            {
                Console.WriteLine(ex.Message);
                newRover(EndOfPlatau);
            }

        }

        static void play(Rover rover, Position EndOfPlatau)
        {
            try
            {
                Console.WriteLine("Please choose a command: 'L' or 'R' to change direction, or 'M' to move forward.\n");
                string input;

                if ((input = Console.ReadLine()) != "exit")
                {
                    rover.Move(input, EndOfPlatau);
                    PrintCurrentLocation(rover);
                    Console.WriteLine("Please choose a command: 'L' or 'R' to change direction, or 'M' to move forward.\n");
                }
            }
            catch (InvalidInputException ex)
            {
                Console.WriteLine(ex.Message);
                play(rover, EndOfPlatau);
            }
        }

        static void PrintCurrentLocation(Rover rover)
        {
            Location location = rover.GetLocation();
            Console.WriteLine("The rover has moved to " + location.position.xPosition + " " + location.position.yPosition + " " + location.direction.PrintID() + " ");
        }

        public static Position GetPosition(string xyPos)
        {
            string[] coordinates = xyPos.Split(" ");
            string errorMessage = "Incorrect X and Y input!";

            if (coordinates.Length != 2)
                throw new InvalidInputException(errorMessage);

            int x, y;
            if (Int32.TryParse(coordinates[0], out x) && Int32.TryParse(coordinates[1], out y))
                return new Position { xPosition = x, yPosition = y };

            throw new InvalidInputException(errorMessage);
        }

        public static Direction GetDirection(char direction)
        {
            switch (direction)
            {
                case 'N':
                    return new North();
                case 'E':
                    return new East();
                case 'S':
                    return new South();
                case 'W':
                    return new West();
                default:
                    throw new InvalidInputException("\nIncorrect input! Possible directions for the rover: 'N', 'E', 'S' or 'W'!");
            }
        }
    }
}
