using System;

namespace Planet
{
    public class GasStationAlreadyExistsException : Exception
    {
        public GasStationAlreadyExistsException(string message) : base(message)
        {
        }
    }
}