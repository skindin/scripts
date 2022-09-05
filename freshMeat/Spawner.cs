using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner main;

    public List<GameObject> prefabs;
    public List<string> menu;
    public List<Animal> animals;
    public Vector3 spawnBox;
    public int minAnimals = 30;
    public float spawnRate = 5;
    float prevSpawnTime = 0;

    private void Awake()
    {
        if (main == null)
        {
            main = this;
        }
    }

    private void Start()
    {
        foreach (var animal in animals)
        {
            menu.Add(animal.meat);
        }
    }

    private void Update()
    {
        if (UIManager.main.inGame)
        {
            while (animals.Count < minAnimals)
            {
                SpawnAnimal();
            }

            float timer = OrderManager.main.timer;

            if (timer - prevSpawnTime > spawnRate)
            {
                SpawnAnimal();
                prevSpawnTime = timer;
            }
        }
    }

    void SpawnAnimal ()
    {
        var index = Random.Range(0, prefabs.Count);
        var newObj = prefabs[index]; //choose random animal from list
        var box = spawnBox / 2;
        var pos = new Vector3(Random.Range(-box.x, box.x), Random.Range(-box.y, box.y), Random.Range(-box.z, box.z)) + Vector3.up * 10;
        var rot = Quaternion.AngleAxis(Random.Range(0, 360), Vector3.up);
        var obj = Instantiate(newObj, pos, rot, transform);
        animals.Add(obj.GetComponent<Animal>());
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position + Vector3.up * 10, spawnBox);
    }
}
