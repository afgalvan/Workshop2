using System;

namespace Domain.People
{
    public class InvalidGenreException : Exception
    {
        public InvalidGenreException(string message) : base(message)
        {
        }
    }
}
