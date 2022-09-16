using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchObject : MonoBehaviour
{
    public ColorID colorID;

    private void Start()
    {
        //RevealColor();
    }

    public void RevealColor ()
    {
        GetComponent<SpriteRenderer>().color = colorID.color;
    }
}
