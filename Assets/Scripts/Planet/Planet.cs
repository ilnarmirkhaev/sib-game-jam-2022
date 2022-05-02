using Core;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Planet
{
    public class Planet : MonoBehaviour
    {
        // Objects
        private Transform _sun;
        private Transform _transform;
        
        // Parameters
        private float _rotationSpeed;
        private Vector3 _rotation;

        private float _radius;
        
        // Resources
        private int _goldPoints;
        private int _gasPoints;
        
        // Buildings
        private bool _hasCannon;
        private bool _hasGasStation;
        private bool _hasGoldStation;

        private void Start()
        {
            _transform = transform;
            _sun = GameManager.Instance.sun;
            Init();
        }

        private void Init()
        {
            _rotation = Random.value switch
            {
                >= 0.5f => Vector3.forward,
                _ => Vector3.back
            };
            
            _rotationSpeed = Random.Range(5, 20);
            _radius = Random.Range(30, 50);
            _transform.localScale *= _radius;
        }

        private void FixedUpdate()
        {
            Rotate();
        }

        private void Rotate()
        {
            transform.RotateAround(_sun.position, _rotation, _rotationSpeed * Time.fixedDeltaTime);
        }

        public void BuildGasStation()
        {
            if (_hasGasStation)
            {
                throw new GasStationAlreadyExistsException("");
            }

            _hasGasStation = true;
        }

        public void BuildGoldStation()
        {
            if (_hasGoldStation)
            {
                throw new GoldStationAlreadyExistsException("");
            }

            _hasGoldStation = true;
        }

        public void BuildCannon()
        {
            if (_hasCannon)
            {
                throw new CannonAlreadyExistsException("");
            }

            _hasCannon = true;
        }
    }
}