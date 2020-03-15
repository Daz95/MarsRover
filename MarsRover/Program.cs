using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {



            Position startPos = GetStartPosition();
            Direction startDir = GetStartDirection();
            Rover myRover = new Rover(startPos, startDir);
            PrintCurrentLocation(myRover);


            Console.WriteLine("\nJust type 'exit' at any time to leave!");

            play(myRover);

        }

        static void play(Rover rover)
        {
            try
            {
                Console.WriteLine("Please choose a command: 'L' or 'R' to change direction, or 'M' to move forward.\n");
                string input;

                while ((input = Console.ReadLine()) != "exit")
                {
                    rover.Move(input);
                    PrintCurrentLocation(rover);
                    Console.WriteLine("Please choose a command: 'L' or 'R' to change direction, or 'M' to move forward.\n");
                }
            }
            catch (InvalidInputException ex)
            {
                Console.WriteLine(ex.Message);
                play(rover);
            }
        }

        static void PrintCurrentLocation(Rover rover)
        {
            Location location = rover.GetLocation();
            Console.WriteLine("Rover is currently at " + location.position.xPosition + "," + location.position.yPosition + "," + location.direction.PrintID() + ".");
            Console.WriteLine("What's the next move?\n");
        }

        static Direction GetStartDirection()
        {
            try
            {
                Console.WriteLine("Please input your rover's starting direction: 'N', 'E', 'S' or 'W'!\n");
                string input = Console.ReadLine();
                return GetDirection(input);
            }

            catch (InvalidInputException ex)
            {
                Console.WriteLine(ex.Message);
                return GetStartDirection();
            }
        }

        static Position GetStartPosition()
        {
            try
            {
                Console.WriteLine("Please input your rover's starting location as coordinates: 'X Y'");
                Console.WriteLine("For example: '0 0'\n");
                string input = Console.ReadLine();
                return Rover.GetPosition(input);
            }

            catch (InvalidInputException ex)
            {
                Console.WriteLine(ex.Message);
                return GetStartPosition();
            }
        }

        public static Direction GetDirection(string direction)
        {
            switch (direction)
            {
                case "N":
                    return new North();
                case "E":
                    return new East();
                case "S":
                    return new South();
                case "W":
                    return new West();
                default:
                    throw new InvalidInputException("\nIncorrect input! Possible directions for the rover: 'N', 'E', 'S' or 'W'!");
            }
        }
    }
}
