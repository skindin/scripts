using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<ItemStack> items;
    public Text inventoryText;
    public GameObject bloodParticle;

    public static Inventory main;
    private void Awake()
    {
        if (main == null)
            main = this;
    }

    public float deliveryForce = 10;
    public float deliveryDelay = .2f;

    public void ShootOrder (Order order)
    {
        List<GameObject> prefabs = new();

        foreach (var item in order.items)
        {
            foreach (var prefab in Spawner.main.prefabs)
            {
                var animal = prefab.GetComponent<Animal>();
                if (item.Name == animal.meat)
                {
                    for (var i = 0; i < item.count; i++)
                    {
                        prefabs.Add(animal.meatPref);
                    }
                    break;
                }
            }
        }

        StartCoroutine(ShootObjectList(prefabs, order.adress.location));
    }

    IEnumerator ShootObjectList(List<GameObject> prefabs, Vector3 target)
    {
        if (prefabs.Count > 0)
        {
            int index = Random.Range(0, prefabs.Count);
            var meatPref = prefabs[index];
            var newObj = Instantiate(meatPref, transform.position + Vector3.up * 2, Random.rotation);
            var rigBod = newObj.GetComponent<Rigidbody>();
            var direction = (target - transform.position).normalized + Vector3.up;
            direction.y = 0;
            rigBod.AddForce(deliveryForce * direction, ForceMode.Impulse);
            rigBod.AddTorque(Random.insideUnitSphere * deliveryForce * 100, ForceMode.Impulse);
            prefabs.RemoveAt(index);
            Destroy(newObj, 1f);
            yield return new WaitForSeconds(deliveryDelay);
                StartCoroutine(ShootObjectList(prefabs, target));
        }
    }

    public void UpdateUI ()
    {
        string text = "Inventory\n\n";
        foreach (var i in items)
        {
            if (i.count > 0)
                text += i.Name + " x" + i.count + "\n";
        }
        inventoryText.text = text;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var animal = collision.gameObject.GetComponent<Animal>();
        if (animal != null) //if the player has hit an animal, add the animals meat to the inventory and destroy the animal
        {
            var blood = Instantiate(bloodParticle, collision.contacts[0].point, Quaternion.identity);
            blood.GetComponent<AudioSource>().pitch = Random.Range(.5f, 1);

            ItemStack.AddStacks(items,new ItemStack(animal.meat, 1));
            UpdateUI();
            Spawner.main.animals.Remove(animal);
            Destroy(collision.gameObject);
        }
    }
}

[System.Serializable]
public class ItemStack
{
    public string Name;
    public int count;

    public ItemStack(string newName, int newCount = 1)
    {
        Name = newName;
        count = newCount;
    }

    public static void AddStacks(List<ItemStack> mainStacks, ItemStack item)
    {
        bool found = false;

        foreach (var mainStack in mainStacks)
        {
            if (mainStack.Name == item.Name)
            {
                mainStack.count += item.count;
                found = true;
            }
        }
        if (!found)
            mainStacks.Add(new ItemStack(item.Name, item.count));
    }

    public static void AddMultStacks (List<ItemStack> mainStacks, List<ItemStack> addStacks)
    {
        foreach (var addStack in addStacks)
        {
            AddStacks(mainStacks, addStack);
        }
    }

    public static void RemoveMultStacks(List<ItemStack> mainStacks, List<ItemStack> removeStacks)
    {
        foreach (var removeStack in removeStacks)
        {
            foreach (var mainStack in mainStacks)
            {
                if (mainStack.Name == removeStack.Name && mainStack.count >= removeStack.count)
                {
                    mainStack.count -= removeStack.count;
                }
            }
        }
    }

    public static bool TestStacks (List<ItemStack> mainStacks, List<ItemStack> compStacks)
    {
        int matches = 0;
        foreach (var compStack in compStacks)
        {
            foreach (var mainStack in mainStacks)
            {
                if (mainStack.Name == compStack.Name && mainStack.count >= compStack.count)
                {
                    matches++;
                }
            }
        }

        return matches >= compStacks.Count;
    }

    public static void Purge<T>(List<T> list)
    {
        int index = 0;
        List<int> nullSlots = new();
        foreach (var obj in list)
        {
            if (obj == null)
            {
                nullSlots.Add(index);
            }
            index++;
        }

        index = 0;
        foreach (var slot in nullSlots)
        {
            list.RemoveAt(nullSlots[index]);
            index++;
        }
    }
}
