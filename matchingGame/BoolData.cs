using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BoolData : ScriptableObject
{
    public bool data;

    public void SetBool (bool a)
    {
        data = a;
    }
}
