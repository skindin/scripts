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
        Debug.Log("game over re*ard");
        gameOverEvent.Invoke();
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
