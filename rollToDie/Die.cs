using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Die : MonoBehaviour
{
    public Type type;
    public Side[] sides;
    public int sideCount;
    public Character character;

    // Start is called before the first frame update
    void Start()
    {
        sideCount = (int)type;
        sides = new Side[sideCount];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Roll ()
    {
        var sideIndex = Random.Range(1, sideCount);
        sides[sideIndex].sideEvent.Invoke();
    }

    public enum Type
    {
        coin = 2, 
        d4 = 4, 
        d6 = 6, 
        d10 = 10, 
        d12 = 12, 
        d20 = 20
    }

    [System.Serializable]
    public class Side
    {
        public string Name;
        public Image image;
        public UnityEvent sideEvent;
        Die die;

        public Side(Die newDie)
        {
            die = newDie;
        }

        public void DamageCharacter (int damage)
        {
            die.character.Damage(damage);
        }

        public void HealCharacter (int healAmount)
        {
            die.character.Heal(healAmount);
        }

        public void AreaRoll (float radius)
        {

        }
    }
}
