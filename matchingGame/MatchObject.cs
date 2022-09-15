using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchObject : MonoBehaviour
{
    public ColorID colorID;

    private void Start()
    {
        GetComponent<SpriteRenderer>().color = colorID.color;
    }
}
