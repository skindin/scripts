using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RepeatingCoroutine : MonoBehaviour
{
    public BoolData condition;
    public float intervalTime = 1;
    WaitForSeconds wfsecs;
    public UnityEvent startEvent, timedEvent, endEvent;

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
        startEvent.Invoke();
        condition.data = true;

        while (condition.data)
        {
            timedEvent.Invoke();
            //cycleData.AddValue(-1);

            wfsecs = new(intervalTime);
            yield return wfsecs;
        }

        endEvent.Invoke();
    }

    public void TestData (IntData data)
    {
        condition.data = data.value > 1;
    }
}