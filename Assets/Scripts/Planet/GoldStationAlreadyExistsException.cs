using System;

namespace Planet
{
    public class GoldStationAlreadyExistsException : Exception
    {
        public GoldStationAlreadyExistsException(string message) : base(message) { }
    }
}
