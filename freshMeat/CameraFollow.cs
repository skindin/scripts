using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float turnSpeed;

    private void LateUpdate()
    {
        transform.position = target.position;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(target.forward), turnSpeed * Time.deltaTime);
    }
}
