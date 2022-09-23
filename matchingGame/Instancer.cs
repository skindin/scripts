using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instancer : MonoBehaviour
{
    public GameObject prefab;
    public Vector3DataList positions;

    public void GenerateRing ()
    {
        var pos = DataList.RandomFromList(positions.data).value;
        GameObject ring = Instantiate(prefab, pos+transform.position, Quaternion.identity);

        Destroy(ring, 2);
    }

    private void OnDrawGizmos()
    {
        foreach (var pos in positions.data)
        {
            Gizmos.DrawWireSphere(pos.value + transform.position, .5f);
        }
    }
}
