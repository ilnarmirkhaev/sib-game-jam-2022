using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    public class PlanetDetection : MonoBehaviour
    {
        [SerializeField] private float detectRange;
        private Vector3 _detectPoint;
        [SerializeField] private LayerMask layerMask;
        private PlayerController _playerController;

        private void Awake()
        {
            _detectPoint = transform.position;
            _playerController = GetComponent<PlayerController>();
        }

        private void Update()
        {
            DetectPlanet();
        }

        private void DetectPlanet()
        {
            var planet = Physics2D.OverlapCircle(_detectPoint, detectRange, layerMask).gameObject;
            // if (planet != null)
            //     _playerController.AttachToPlanet(planet);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(_detectPoint, detectRange);
        }
    }
}
