using System;

namespace CopaDeFilmes.Application.Exceptions
{
    public class InvalidNumberOfMoviesException : Exception
    {
        public InvalidNumberOfMoviesException()
        {
        }

        public InvalidNumberOfMoviesException(string message) : base(message)
        {
        }
    }
}
