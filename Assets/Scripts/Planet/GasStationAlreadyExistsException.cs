using System;
using UnityEngine;

public class GasStationAlreadyExistsException : Exception
{
    public GasStationAlreadyExistsException(string message) : base(message) { }
}
