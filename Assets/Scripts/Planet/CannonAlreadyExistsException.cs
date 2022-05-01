using System;
using UnityEngine;

public class CannonAlreadyExistsException : Exception
{
    public CannonAlreadyExistsException(string message) : base(message) { }
}
