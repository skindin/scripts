using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MatchingGameManager : MonoBehaviour
{
    public UnityEvent onStart, onGo, gameOverEvent;

    public void Start()
    {
        onStart.Invoke();
    }

    public void GameOver ()
    {
        gameOverEvent.Invoke();
        Debug.Log("this is literally the easiest game ever how did you lose");
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Go ()
    {
        onGo.Invoke();
    }
}
