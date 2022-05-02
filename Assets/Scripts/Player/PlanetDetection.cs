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

        [SerializeField] private float cooldownTime = 0.5f;
        public float timeFromDetachment;

        private void Awake()
        {
            _detectPoint = transform.position;
            _playerController = GetComponent<PlayerController>();
            detectRange = gameObject.GetComponent<Collider2D>().bounds.extents.x;
        }

        private void Update()
        {
            if (_playerController.isAttached) return;
            
            timeFromDetachment += Time.deltaTime;
            
            if (timeFromDetachment >= cooldownTime)
                DetectPlanet();
        }

        private void DetectPlanet()
        {
            
            var planet = Physics2D.OverlapCircle(_detectPoint, detectRange, layerMask).transform;
            if (planet != null)
            {
                Debug.Log($"Detected planet: {planet}");
                _playerController.AttachToPlanet(planet);
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(_detectPoint, detectRange);
        }
    }
}
