using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public string Name;
    public string meat;
    public GameObject meatPref;

    public float jumpForce = 100;
    public float fleeDistance = 10;
    Rigidbody rigbod;
    Transform predator;

    private void Start()
    {
        rigbod = GetComponent<Rigidbody>();
        predator = FindObjectOfType<VehicleController>().transform;
    }

    private void FixedUpdate()
    {
        if (rigbod.velocity.magnitude == 0)
        {
            OnCollisionEnter();
        }
    }

    private void OnCollisionEnter(Collision collision = null)
    {
        if (Vector3.Distance(transform.position, predator.position) <= fleeDistance)
        {
            var direction = transform.position - predator.position;
            direction.y = 0;
            direction.Normalize();
            rigbod.AddForce((direction + Vector3.up) * jumpForce);

            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}
