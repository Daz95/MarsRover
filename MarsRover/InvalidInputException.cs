using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class InvalidInputException : Exception
    {
        public InvalidInputException(string message) : base(message)
        {
        }
    }
}
