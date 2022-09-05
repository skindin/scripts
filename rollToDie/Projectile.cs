using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10;
    public float range = 10;
    public Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        var duration = range / speed;
        Destroy(gameObject, duration);
        //set rotation to direction
    }

    // Update is called once per frame
    void Update()
    {
        Move(direction, speed);
    }

    public void Move(Vector3 direction, float speed)
    {

    }
}
