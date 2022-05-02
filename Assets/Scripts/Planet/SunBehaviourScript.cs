using UnityEngine;

namespace Planet
{
    public class SunBehaviourScript : MonoBehaviour
    {
        public Vector3 GetSunPosition()
        {
            return transform.position;
        }
    }
}