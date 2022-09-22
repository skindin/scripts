using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class IntData : ScriptableObject
{
    public int value;

    public void AddValue (int num)
    {
        value += num;
    }

    public void SetValue (int num)
    {
        value = num;
    }

    public void MaxValue (IntData data)
    {
        if (value < data.value)
            value = data.value;
    }
}
