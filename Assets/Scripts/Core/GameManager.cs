using System.Collections.Generic;
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
        private Camera _camera;
        
        public GameObject[] planetPrefabs;
        [HideInInspector] public List<GameObject> planets = new List<GameObject>();
        
        public GameObject playerPrefab;
        [HideInInspector] public GameObject player;

        private void Start()
        {
            _camera = Camera.main;
            sun = GameObject.Find("Sun").transform;
            
            if (planetPrefabs.Length <= 0) return;
            
            orbitCount = Random.Range(5, 11);
            
            GeneratePlanets();
            SpawnPlayer();
        }

        private void GeneratePlanets()
        {
            var distance = sun.GetComponent<SpriteRenderer>().bounds.size.x;
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
            
            planets.Add(planet);
        }

        private void SpawnPlayer()
        {
            var planetToSpawn = planets[0];
            var r = planetToSpawn.GetComponent<Collider2D>().bounds.extents.x;
            var offset = new Vector3(r + playerPrefab.transform.localScale.x, 0, 0);
            
            player = Instantiate(playerPrefab, planetToSpawn.transform.position + offset, Quaternion.identity);
            _camera.GetComponent<CameraFollow>().player = player.transform;
        }
    }
}
