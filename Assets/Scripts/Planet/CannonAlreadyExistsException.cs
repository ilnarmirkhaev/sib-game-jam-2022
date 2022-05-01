using System;

public class CannonAlreadyExistsException : Exception
{
    public CannonAlreadyExistsException(string message) : base(message)
    {
    }
}