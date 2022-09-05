using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager main;

    public bool inGame = false;

    public GameObject gameUI;
    public GameObject tip;
    public GameObject mainMenu;
    public GameObject gameOverMenu;
    public Text scoreText;

    private void Awake()
    {
        if (main == null)
            main = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            tip.SetActive(!tip.activeSelf);
        }
    }

    public void GameOver ()
    {
        inGame = false;

        gameUI.SetActive(false);
        gameOverMenu.SetActive(true);

        string scoreString = "";

        float score = OrderManager.main.timer;
        float highScore = PlayerPrefs.GetFloat("highScore", 0);
        bool newHighScore = score > highScore;

        if (newHighScore)
        {
            PlayerPrefs.SetFloat("highScore", score);
            scoreString += "New High Score\n";
        }

        scoreString += Order.FloatToTimeString(score) + "\n";

        if (!newHighScore)
        {
            scoreString += "High Score " + Order.FloatToTimeString(highScore);
        }

        scoreText.text = scoreString;
    }

    public void PlayGame ()
    {
        inGame = true;

        gameUI.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void Restart ()
    {
        SceneManager.LoadScene(0);
    }
}
