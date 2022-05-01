using System;
using UnityEngine;

public class PlanetRotationBehaviourScript : MonoBehaviour
{
    [SerializeField] private GameObject sun;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private int rotateDirection = -1;

    [SerializeField] private int gasPoints;
    [SerializeField] private int goldPoints;

    private float _size;

    private Planet _planet;

    private Vector3 _distanceVector;

    // Start is called before the first frame update
    void Start()
    {
        _distanceVector = -sun.transform.position + transform.position;

        var planetMovement = rotateDirection < 0 ? RotateDirection.Counterclockwise : RotateDirection.Сlockwise;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float singleStepAngle = rotationSpeed * Time.deltaTime;
         
        RotatePlanet(singleStepAngle);
    }

    private void RotatePlanet(float angle)
    {
        _distanceVector = RotateVector(_distanceVector, angle);
        transform.position = sun.transform.position + _distanceVector;
    }

    private Vector3 RotateVector(Vector3 v, float angle)
    {
        if (rotateDirection < 0)
        {
            angle = -angle;
        }

        v = Quaternion.AngleAxis(angle, Vector3.forward) * v;
        return v;
    }
}