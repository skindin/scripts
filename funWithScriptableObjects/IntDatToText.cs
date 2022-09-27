using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class IntDatToText : MonoBehaviour
{
    public Text text;
    public IntData data;
    public UnityEvent UpdatedTextEvent;

    private void Start()
    {
        text.text = data.value + "";
    }

    public void UpdateText()
    {
        var newText = data.value + "";

        if (text.text != newText)
        {
            UpdatedTextEvent.Invoke();
            text.text = newText;
        }
    }
}
