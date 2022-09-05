using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdressManager : MonoBehaviour
{
    public static AdressManager main;
    public GameObject markerPrefab;
    public Transform minimapCanvas;
    private void Awake()
    {
        if (main == null)
            main = this;

        foreach (var adress in adresses)
        {
            vacantAdresses.Add(adress);
        }
    }

    public List<Adress> adresses = new();
    public List<Adress> vacantAdresses = new();
    public VehicleController foodTruck;

    private void Start()
    {
        foodTruck = FindObjectOfType<VehicleController>();
    }

    private void Update()
    {
        foreach (var adress in adresses)
        {
            var truckPos = foodTruck.transform.position;
            if (Vector3.Distance(truckPos,adress.location) <= adress.radius)
            {
                if (adress.order != null)
                {
                    var success = OrderManager.CompleteOrder(adress.order, Inventory.main.items);
                    if (success)
                    {
                        adress.order = null;
                    }
                }
            }

            if (adress.marker == null)
            {
                var marker = Instantiate(markerPrefab, Vector3.zero, minimapCanvas.rotation, minimapCanvas);
                marker.transform.position = new Vector3(adress.location.x, minimapCanvas.position.y, adress.location.z);
                adress.marker = marker.GetComponent<Text>();
            }

            if (adress.order == null)
            {
                adress.marker.text = "";
            }
        }

        int index = 1;
        foreach (var order in OrderManager.main.orders)
        {
            order.adress.marker.text = index + "";
            index++;
        }
    }

    private void OnDrawGizmos()
    {
        foreach (var adress in adresses)
        {
            Gizmos.DrawWireSphere(adress.location, adress.radius);
        }
    }
}

[System.Serializable]
public class Adress
{
    public Vector3 location;
    public float radius;
    public Order order;
    public Text marker;
}
