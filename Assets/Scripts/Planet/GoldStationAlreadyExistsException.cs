using System;
using UnityEngine;

public class GoldStationAlreadyExistsException : Exception
{
    public GoldStationAlreadyExistsException(string message) : base(message) { }
}
