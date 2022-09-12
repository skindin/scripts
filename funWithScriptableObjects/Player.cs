using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public IntData amoCount;
    public Vector3Data checkPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot ()
    {
        if (amoCount.value > 0)
        {
            //spawn bullet/amo
            amoCount.value--;
        }
    }

    public void SetCheckpoint (Vector3 point)
    {
        checkPoint.value = point;
    }

    public void Respawn ()
    {
        transform.position = checkPoint.value;
    }
}
