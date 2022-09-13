using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterClass : MonoBehaviour
{
    public string Name;
    public List<CharacterClass> classes = new();

    public UnityEvent ability1;
    public UnityEvent ability2;

    public UnityEvent reaction;

    private void OnCollisionEnter(Collision collision)
    {
        reaction.Invoke();
    }

    private void OnMouseDown()
    {
        ability1.Invoke();
    }

    private void OnMouseDrag()
    {
        ability2.Invoke();
    }

    void Stab ()
    {

    }

    void Swing() { }

    void Shoot ()
    {

    }

    void Dash() { }

    void Smash ()
    {

    }

    void Throw() { }

    void Strum ()
    {

    }

    void Sing() { }

    void OffenseSpell()
    {

    }

    void DeffenseSpell ()
    {

    }
}
