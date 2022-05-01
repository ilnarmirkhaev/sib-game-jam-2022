using System;
using UnityEngine;

public class Planet
{
    
    // init this in constructor
    private int _distance;
    private PlanetMovement _movement;
    private int _goldPoints;
    private int _gasPoints;

    public Planet()
    {
        // TODO
        throw new NotImplementedException();
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
}
