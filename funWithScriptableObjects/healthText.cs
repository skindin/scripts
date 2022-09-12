using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthText : MonoBehaviour
{
    public Text text;
    public FloatData health;

    private void Update()
    {
        text.text = health.value + "";
    }
}
