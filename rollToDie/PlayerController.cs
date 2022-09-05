using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController main;
    public Character character;

    private void Awake()
    {
        if (main == null) main = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //roll die when spacebar is hit
        {
            character.die.Roll();
        }

        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");
        var moveDirection = new Vector3(x, y, 0);
        character.Move(moveDirection);
    }

    public void ShootTowards(Vector3 position)
    {
        Vector2 direction = position - transform.position;
        character.Shoot(direction);
    }
}
