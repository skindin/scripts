using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchObject : MonoBehaviour
{
    public static List<MatchObject> matchObjs = new();

    public ColorID colorID;
    Color ogColor;
    SpriteRenderer sprite;

    private void Start()
    {
        matchObjs.Add(this);
        //RevealColor();
        sprite = GetComponent<SpriteRenderer>();
        ogColor = sprite.color;
    }

    public void RevealColor ()
    {
        sprite.color = colorID.color;
    }

    void ResetColor ()
    {
        sprite.color = ogColor;
    }

    static void ResetColors()
    {
        foreach (var obj in matchObjs)
        {
            obj.ResetColor();
        }
    }

    public void ResetAll ()
    {
        ResetColors();
    }
}
