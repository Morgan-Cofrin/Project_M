using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private Vector3 velocity = Vector3.zero;

    public float smoothSpeed = 0.25f;
    public Vector3 offset = new Vector3(0f, 2f, -10f); //Doesn't actually do much because of orthographic camera, change size to see more

    [SerializeField] private Transform target;


    //Remember to attach the camera to the target
    void FixedUpdate()
    {
        SmoothDampCameraFollow();

    }

    private void SmoothDampCameraFollow()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothSpeed);
    }

}
