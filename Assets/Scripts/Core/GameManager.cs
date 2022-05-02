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

        public int orbitCount;
        [HideInInspector] public Transform sun;
        public GameObject[] planetPrefabs;

        private void Start()
        {
            sun = GameObject.Find("Sun").transform;
            
            if (planetPrefabs.Length <= 0) return;
            
            orbitCount = Random.Range(5, 11);
            GeneratePlanets();
        }

        private void GeneratePlanets()
        {
            var distance = 0f;
            for (var i = 0; i < orbitCount; i++)
            {
                // var planetCount = Random.Range(1, 4);
                var planetCount = 1;
                distance += 50;
                // float angleOffset = Random.Range(0, 360);
                float angleOffset = 0;
                
                for (var j = 0; j < planetCount; j++)
                {
                    angleOffset += 360f / planetCount;
                    
                    SpawnPlanet(distance, angleOffset);
                }
            }
        }

        private void SpawnPlanet(float distance, float angleOffset)
        {
            var offset = new Vector3(distance, 0, 0);
            var i = Random.Range(0, planetPrefabs.Length);
            
            
            var planet = Instantiate(planetPrefabs[i], sun.position + offset, Quaternion.identity);
            planet.transform.RotateAround(sun.position, Vector3.forward, angleOffset);
        }
    }
}
