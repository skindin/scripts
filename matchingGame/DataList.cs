using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataList : ScriptableObject
{

    public static T RandomFromList<T>(List<T> list)
    {
        int index = Random.Range(0, list.Count);
        return list[index];
    }
}
