using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FunWithEvents : MonoBehaviour
{
    MeshRenderer mesh;
    Color ogColor;
    public UnityEvent touchEvent;
    public UnityEvent untouchEvent;

    private void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        ogColor = mesh.material.color;
    }

    private void OnTriggerEnter(Collider other)
    {
        touchEvent.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        untouchEvent.Invoke();
    }

    public void RandomHue ()
    {
        float hue = Random.value;
        var color = Color.HSVToRGB(hue, 1, 1);
        mesh.material.color = color;
    }

    public void ReturnToOGColor()
    {
        mesh.material.color = ogColor;
    }
}
