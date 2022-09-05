using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Die die;
    public int maxHealth = 1;
    public int health;
    public float moveSpeed = 5;
    public GameObject projectilePrfb;
    public Vector3 projectilePoint = Vector3.zero;

    public Rigidbody rigbod;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        rigbod = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move (Vector3 direciton)
    {
        rigbod.velocity = direciton * moveSpeed;
    }

    public void Shoot (Vector3 direction)
    {
        var obj = Instantiate(projectilePrfb, GetProjectilePoint(), Quaternion.identity);
        var projectile = obj.GetComponent<Projectile>();
        projectile.direction = direction;
    }

    public void Damage (int damage)
    {
        health -= damage;
    }

    public void Heal (int healAmount)
    {
        healAmount += healAmount;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(GetProjectilePoint(), 1);
    }

    Vector3 GetProjectilePoint ()
    {
        return transform.rotation * projectilePoint + transform.position;
    }
}
