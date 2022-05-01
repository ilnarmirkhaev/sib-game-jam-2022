using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    [SerializeField] private Transform player;
    private readonly Vector3 _offset = new Vector3(0, 1, -5);
    
    public float smooth= 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp (
            transform.position, player.position + _offset,
            Time.deltaTime * smooth);
    }
}
