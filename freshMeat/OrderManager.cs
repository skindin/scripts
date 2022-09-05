using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderManager : MonoBehaviour
{
    public float initialRate = 20;
    public float accRate = 1;
    public float minRate = 2;
    public float customerPatience = 60;
    public float timer = 0;
    float prevOrderTime = 0;

    public int maxItemCount = 5;

    public List<Order> orders = new();
    public Text orderText;
    public Text scoreText;

    public static OrderManager main;
    private void Awake()
    {
        if (main == null)
        {
            main = this;
        }
    }

    private void Update()
    {
        if (UIManager.main.inGame)
        {
            var orderRate = (initialRate - minRate) * Mathf.Pow(accRate, -timer) + minRate;
            //Debug.Log(orderRate);

            if (timer - prevOrderTime >= orderRate || timer == 0)
            {
                var success = newOrder();
                if (success)
                    prevOrderTime = timer;
            }

            timer += Time.deltaTime;

            foreach (var order in orders)
            {
                order.time -= Time.deltaTime;

                scoreText.text = Order.FloatToTimeString(timer);

                if (order.time < 0)
                {
                    UIManager.main.GameOver();
                }
            }

            UpdateOrderText();

            ItemStack.Purge(orders);
        }
    }

    bool newOrder ()
    {
        if (orders.Count < AdressManager.main.adresses.Count)
        {

            var items = new List<ItemStack>();
            int itemCount = Random.Range(1, maxItemCount);

            for (var i = 0; i < itemCount; i++)
            {
                var menu = Spawner.main.menu;
                var newItem = new ItemStack(menu[Random.Range(0, menu.Count)], 1);
                ItemStack.AddStacks(items, newItem);
            }

            var vacantAdresses = AdressManager.main.vacantAdresses;

            var adress = vacantAdresses[Random.Range(0, vacantAdresses.Count)];

            var order = new Order(items, customerPatience, adress);
            orders.Add(order);
            vacantAdresses.Remove(adress);
            adress.order = order;

            order.Name = order.InString();

            return true;
        }
        else 
            return false;
    }

    void UpdateOrderText ()
    {
        var text = "Orders\n\n";

        int index = 1;
        foreach (var order in orders)
        {
            text += index + ". " + order.InString() + "\n";
            index++;
        }

        orderText.text = text;
    }

    public static bool CompleteOrder (Order order, List<ItemStack> inventory)
    {
        if (ItemStack.TestStacks(inventory, order.items))
        {
            ItemStack.RemoveMultStacks(inventory, order.items);
            Inventory.main.UpdateUI();
            main.orders.Remove(order);
            AdressManager.main.vacantAdresses.Add(order.adress);
            Inventory.main.ShootOrder(order);
            return true;
        }
        else
            return false;
    }
}

//[System.Serializable]
public class Order
{
    public string Name;
    public List<ItemStack> items;
    public float time;
    public Adress adress;

    public Order(List<ItemStack> newItems, float newTime, Adress newAdress)
    {
        items = newItems;
        time = newTime;
        adress = newAdress;
    }

    public string InString ()
    {
        string text = "";
        foreach (var item in items)
        {
            text += item.Name + " x" + item.count + ", ";
        }

        text += FloatToTimeString(time);
        return text;
    }

    public static string FloatToTimeString (float time)
    {
        int intTime = Mathf.RoundToInt(Mathf.Clamp(time,0,Mathf.Infinity));
        var minutes = intTime / 60;
        var seconds = intTime % 60;

        string timeString = "";
        //if (minutes < 10)
        //    timeString += "0";
        timeString += minutes + ":";
        if (seconds < 10)
            timeString += "0";
        timeString += seconds;

        return timeString;
    }
}