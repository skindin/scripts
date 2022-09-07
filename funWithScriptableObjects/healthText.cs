using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthText : MonoBehaviour
{
    public Text text;
    public FloatValue health;

    private void Update()
    {
        text.text = health.value + "";
    }
}
