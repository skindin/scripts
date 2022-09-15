using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntDatToText : MonoBehaviour
{
    public Text text;
    public IntData data;

    private void Update()
    {
        text.text = data.value + "";
    }
}
