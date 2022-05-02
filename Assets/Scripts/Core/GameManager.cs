using UnityEngine;
using Random = UnityEngine.Random;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }

        public int orbitCount = 42;
        public Transform sun;
        private Vector3 _sunPosition;
        public GameObject planetPrefab;

        private void Start()
        {
            _sunPosition = sun.position;
            GeneratePlanets();
        }

        private void GeneratePlanets()
        {
            var distance = 0f;
            for (var i = 0; i < orbitCount; i++)
            {
                distance += Random.Range(90, 140);
                var rotationSpeed = Random.Range(5, 20);
                var planetCount = Random.Range(1, 4);
                float angle = Random.Range(0, 360);
                for (var j = 0; j < planetCount; j++)
                {
                    var radius = Random.Range(25, 80);
                    angle += 360f / planetCount;
                    GeneratePlanet(distance, radius, rotationSpeed, angle);
                }
            }
        }

        private void GeneratePlanet(float distance, float radius, float rotationSpeed, float angle)
        {
            var planet = Instantiate(planetPrefab, _sunPosition + new Vector3(distance, 0, 0), Quaternion.identity);
            planet.transform.RotateAround(_sunPosition, Vector3.forward, angle);
            var planetScript = planet.AddComponent<Planet.Planet>();
            planetScript.rotationSpeed = rotationSpeed;
            planet.transform.localScale *= radius;
        }
    }
}
