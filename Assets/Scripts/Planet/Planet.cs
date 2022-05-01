using System;
using UnityEngine;

public class Planet
{
    
    // init this in constructor
    private float _distance;
    private RotateDirection _rotateDirection;
    private int _goldPoints;
    private int _gasPoints;

    private float _rotationSpeed = 0;

    public Planet(float distance, RotateDirection rotateDirection, int goldPoints, int gasPoints, float rotationSpeed)
    {
        _distance = distance;
        _rotateDirection = rotateDirection;
        _goldPoints = goldPoints;
        _gasPoints = gasPoints;
        _rotationSpeed = rotationSpeed;
    }
    
    // inner vars
    private int _countOfGasStations = 0;
    private int _countOfGoldStations = 0;
    private int _countOfCannons = 0;


    public void CreateGasStation()
    {
        if (_countOfGasStations > 0)
        {
            throw new GasStationAlreadyExistsException("");
        }

        _countOfGasStations++;
    }

    public void CreateGoldStation()
    {
        if (_countOfGoldStations > 0)
        {
            throw new GoldStationAlreadyExistsException("");
        }
        
        _countOfGoldStations++;
    }

    public void CreateCannon()
    {
        if (_countOfCannons > 0)
        {
            throw new CannonAlreadyExistsException("");
        }
        
        _countOfCannons++;
    }

    public int GetCountOfGasStations()
    {
        return _countOfGasStations;
    }
    
    public int GetCountOfGoldStations()
    {
        return _countOfGoldStations;
    }
    
    public int GetCountOfCannons()
    {
        return _countOfCannons;
    }

    public static void Generate()
    {
        throw new NotImplementedException();
    }
}
