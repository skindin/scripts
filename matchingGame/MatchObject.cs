using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchObject : MonoBehaviour
{
    public static List<MatchObject> matchObjs = new();
    public ColorIDList colorList;

    public ColorID colorID;
    Color ogColor;
    SpriteRenderer sprite;

    private void Start()
    {
        matchObjs.Add(this);
        //RevealColor();
        sprite = GetComponent<SpriteRenderer>();
        ogColor = sprite.color;
        RandomColor();
    }

    public void RevealColor ()
    {
        sprite.color = colorID.color;
    }

    void ResetColor ()
    {
        sprite.color = ogColor;
    }

    public void SetColor (ColorID newColor)
    {
        colorID = newColor;
        sprite.color = newColor.color;
    }

    public void RandomColor ()
    {
        var colorID = DataList.RandomFromList(colorList.colorIDs);
        SetColor(colorID);
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
