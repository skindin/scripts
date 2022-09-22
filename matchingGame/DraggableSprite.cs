using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DraggableSprite : MonoBehaviour
{
    bool dragging = false;
    Vector3 offset;

    public UnityEvent mouseDownEvent;
    public UnityEvent mouseDragEvent;
    public UnityEvent mouseUpEvent;

    private void OnMouseDown()
    {
        dragging = true;
        offset = Camera.main.WorldToScreenPoint(transform.position) - Input.mousePosition;

        mouseDownEvent.Invoke();
    }

    private void OnMouseDrag()
    {
        if (dragging)
        {
            Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition + offset);
            newPos.z = transform.position.z;
            transform.position = newPos;

            mouseDragEvent.Invoke();
        }
    }

    private void OnMouseUp()
    {
        StopDrag();
    }

    public void StopDrag ()
    {
        if (dragging)
        {
            dragging = false;
            mouseUpEvent.Invoke();
        }
    }

    public void ResetPos ()
    {
        transform.position = Vector3.zero;
    }

    public void EnableRaycast (bool a)
    {
        GetComponent<Collider>().enabled = a;
    }
}
