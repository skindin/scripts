using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMatcher : MonoBehaviour
{
    public MatchObject matchObj;

    public UnityEvent correctMatch;
    public UnityEvent incorrectMatch;

    public Instancer instancer;

    private void Awake()
    {
        matchObj = GetComponent<MatchObject>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        var otherMatchObj = collider.GetComponent<MatchObject>();
        if (otherMatchObj != null)
        {
            if (matchObj.colorID == otherMatchObj.colorID)
            {
                correctMatch.Invoke();
                Debug.Log("correct match");
            }
            else
            {
                incorrectMatch.Invoke();
                Debug.Log("incorrect match");
            }

            Destroy(collider.gameObject,.01f);

            matchObj.RandomColor();

            //otherMatchObj.RevealColor();
            //matchObj.RevealColor();
        }
    }
}
