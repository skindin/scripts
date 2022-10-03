using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMatcher : MonoBehaviour
{
    public MatchObject matchObj;

    public UnityEvent correctMatch;
    public UnityEvent incorrectMatch;

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
                transform.parent = otherMatchObj.transform;
                transform.localPosition = Vector3.zero;
                Destroy(otherMatchObj, 0.1f);
                Debug.Log("correct match");
            }
            else
            {
                incorrectMatch.Invoke();
                Debug.Log("incorrect match");
            }

            //Destroy(collider.gameObject,.01f);

            //matchObj.RandomColor();

            //otherMatchObj.RevealColor();
            //matchObj.RevealColor();
        }
    }
}
