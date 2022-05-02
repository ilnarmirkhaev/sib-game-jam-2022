using System;
using UnityEngine;

public class ZoomIn : MonoBehaviour
{
    public Rigidbody2D target;
    [SerializeField] private float minCam;
    [SerializeField] private float maxCam;
    private float playerVel;
    private float smooth = 0.5f;
    private Camera cam;
    private float speed;
    private Vector3 oldPosition;

    void Start()
    {
        cam = Camera.main;
    }

    private void FixedUpdate()
    {
        speed = Vector3.Distance(oldPosition, target.position) * 100f;
        oldPosition = target.position;
    }

    void Update()
    {
        if (target != null)
        {
            float cameraSizeInput = Mathf.Clamp(Mathf.Abs(speed), minCam, maxCam);
				
            float cameraSizeChanger = Mathf.SmoothDamp(cam.orthographicSize, cameraSizeInput, ref playerVel, smooth);

            cam.orthographicSize = cameraSizeChanger;
        }
    }
}