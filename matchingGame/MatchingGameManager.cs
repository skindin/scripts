using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MatchingGameManager : MonoBehaviour
{
    public UnityEvent onStart;
    public UnityEvent gameOverEvent;

    public void Start()
    {
        onStart.Invoke();
    }

    public void GameOver ()
    {
        Debug.Log("this is literally the easiest game ever how did you lose");
        gameOverEvent.Invoke();
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
