using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;

    Vector3 position;

    private void Update()
    {
        position = target.position;
        position.z = -10;

        transform.position = position;
    }
}
