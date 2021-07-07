using System;

namespace RecipeFinder.Application.Exceptions
{
    public class InvalidRequestException : Exception
    {
        public InvalidRequestException()
        {
        }

        public InvalidRequestException(string message) : base(message)
        {
        }
    }
}
