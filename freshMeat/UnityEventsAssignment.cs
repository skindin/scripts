using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventsAssignment : MonoBehaviour
{
    public UnityEvent priority;

    public Transform target;

    private void Start()
    {
        priority.AddListener(delegate { Observe(); });
    }

    private void Update()
    {
        priority.Invoke();

        if (target != null)
        {
            priority.AddListener(delegate { Chase(); });
        }

        if (Vector3.Distance(transform.position,target.position) < 1)
        {
            priority.AddListener(delegate { Chase(); });
        }
    }

    public void Observe()
    {
        //look for targets
    }

    public void Chase()
    {
        //move towards target
    }

    public void Attack ()
    {
        //attack target
    }
}
