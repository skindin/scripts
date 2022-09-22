using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RepeatingCoroutine : MonoBehaviour
{
    public IntData cycleData;
    public int cycleCount = 1;
    WaitForSeconds wfsecs;
    public UnityEvent timedEvent, endEvent;

    // Start is called before the first frame update

    //public void StartTimer(int time = 1)
    //{
    //    cycleData.value = time;

    //    while (cycleData.value > 0)
    //    {
    //        StartCoroutine(StartCycle(1));
    //    }
    //}

    public void StartTimer ()
    {
        StartCoroutine(LoopCoroutine());
    }

    private IEnumerator LoopCoroutine ()
    {
        cycleData.value = cycleCount;

        while (cycleData.value > 0)
        {
            timedEvent.Invoke();
            cycleData.AddValue(-1);

            wfsecs = new(1);
            yield return wfsecs;
        }

        endEvent.Invoke();
    }
}
