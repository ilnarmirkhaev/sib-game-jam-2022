using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    
    private Camera _camera;
    [SerializeField] private float parallaxEffect = 1.1f;
    private float _length, _startposX, _startposY;
    private void Awake()
    {
        _camera = Camera.main;
    }
    void Start()
    {
        _startposX = transform.position.x;
        _startposY = transform.position.y;
    }

    void Update()
    {
        float distX = _camera.transform.position.x * parallaxEffect;
        float distY = _camera.transform.position.y * parallaxEffect;

        transform.position = new Vector3(_startposX + distX, _startposY + distY, transform.position.z);
    }
}
