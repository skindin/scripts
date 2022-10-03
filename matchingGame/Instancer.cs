using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instancer : MonoBehaviour
{
    public GameObject prefab;
    public Vector3DataList positions;
    public Vector3 offset;
    public bool destroyAfterDelay = true;
    public float duration = 2;

    public void GeneratePrefab ()
    {
        var pos = DataList.RandomFromList(positions.data).value;
        GameObject newObj = Instantiate(prefab, pos+transform.position + offset, Quaternion.identity);

        if (destroyAfterDelay)
            Destroy(newObj, duration);
    }

    private void OnDrawGizmos()
    {
        foreach (var pos in positions.data)
        {
            Gizmos.DrawWireSphere(pos.value + transform.position + offset, .5f);
        }
    }

    //public void DestroyAllChildren ()
    //{
    //    var children = transform.GetComponentsInChildren<Transform>();
    //    foreach (var child in children)
    //    {
    //        Destroy(child.gameObject, 1f);
    //    }
    //}
}
