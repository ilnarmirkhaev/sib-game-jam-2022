using UnityEngine;

namespace Core
{
    public class CameraFollow : MonoBehaviour
    {
    
        [HideInInspector] public Transform player;
        private readonly Vector3 _offset = new Vector3(0, 1, -5);
    
        public float smooth = 5.0f;

        private void FixedUpdate()
        {
            if (player != null)
                transform.position = Vector3.Lerp (
                    transform.position, player.position + _offset,
                    Time.deltaTime * smooth
                    );
        }
    }
}
