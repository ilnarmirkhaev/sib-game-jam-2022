using System;

public class GoldStationAlreadyExistsException : Exception
{
    public GoldStationAlreadyExistsException(string message) : base(message)
    {
    }
}