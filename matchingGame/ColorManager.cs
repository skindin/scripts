using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public ColorIDList colors;
    public static ColorIDList matchColors;

    private void Awake()
    {
        matchColors = colors;
    }
}
