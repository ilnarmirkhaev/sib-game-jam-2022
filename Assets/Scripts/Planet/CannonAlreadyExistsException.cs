using System;

namespace Planet
{
    public class CannonAlreadyExistsException : Exception
    {
        public CannonAlreadyExistsException(string message) : base(message)
        {
        }
    }
}