using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour
{
    public static DiceManager manager;
    public List<Die.Side> sides = new ();

    private void Awake()
    {
        if (manager == null) manager = this;
    }
}
