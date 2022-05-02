using System;
using UnityEngine;

namespace Planet
{
    public class Planet : MonoBehaviour
    {
        public float scaleFactor;
        private float _distance;
        private RotateDirection _rotateDirection;
        private int _goldPoints;
        private int _gasPoints;

        public float rotationSpeed = 0;

        private bool _hasCannon;
        private bool _hasGasStation;
        private bool _hasGoldStation;


        public void CreateGasStation()
        {
            if (_hasGasStation)
            {
                throw new GasStationAlreadyExistsException("");
            }

            _hasGasStation = true;
        }

        public void CreateGoldStation()
        {
            if (_hasGoldStation)
            {
                throw new GoldStationAlreadyExistsException("");
            }

            _hasGoldStation = true;
        }

        public void CreateCannon()
        {
            if (_hasCannon)
            {
                throw new CannonAlreadyExistsException("");
            }

            _hasCannon = true;
        }

        public static void Generate()
        {
            throw new NotImplementedException();
        }
    }
}