using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameActionHandler : MonoBehaviour
{
    public GameAction gameActionObj;
    public UnityEvent onRaiseEvent;

    // Start is called before the first frame update
    void Start()
    {
        gameActionObj.raise += Raise;
    }

    // Update is called once per frame
    void Raise()
    {
        onRaiseEvent.Invoke();
    }
}
