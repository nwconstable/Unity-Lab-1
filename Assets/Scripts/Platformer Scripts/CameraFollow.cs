using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Transform mainTransform;
    
    private Vector3 velocity = Vector3.zero;
    void FixedUpdate()
    {
        Vector3 currentPosition = mainTransform.position;
        Vector3 smoothPosition = Vector3.SmoothDamp(mainTransform.position, target.position, ref velocity, 0.15f);
        currentPosition.x = smoothPosition.x;
        mainTransform.position = currentPosition;
    }
}