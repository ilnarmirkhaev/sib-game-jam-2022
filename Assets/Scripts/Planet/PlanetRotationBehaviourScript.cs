using System;
using Core;
using UnityEngine;

public class PlanetRotationBehaviourScript : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 20f;
    [SerializeField] private RotateDirection rotateDirection = RotateDirection.Counterclockwise;
    private Vector3 _rotation;
    private Transform _sun;

    private void Start()
    {
        _sun = GameManager.Instance.sun;
        
        _rotation = rotateDirection switch
        {
            RotateDirection.Counterclockwise => Vector3.forward,
            RotateDirection.Сlockwise => Vector3.back,
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private void Update()
    {
        transform.RotateAround(_sun.position, _rotation, rotationSpeed * Time.deltaTime);
    }
}