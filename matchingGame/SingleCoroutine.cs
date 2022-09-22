using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SingleCoroutine : MonoBehaviour
{
    public UnityEvent timedEvent;
    WaitForSeconds wfsecs;

    public IEnumerator TimedRoutine (float time)
    {
        wfsecs = new(time);
        yield return wfsecs;
        timedEvent.Invoke();
    }

    public void StartTimer (float time)
    {
        StartCoroutine(TimedRoutine(time));
    }
}
