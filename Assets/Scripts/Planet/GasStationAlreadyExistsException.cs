using System;

public class GasStationAlreadyExistsException : Exception
{
    public GasStationAlreadyExistsException(string message) : base(message)
    {
    }
}