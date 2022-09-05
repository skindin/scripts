using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager manager;
    public GameObject mainMenu;
    public GameObject pauseMenu;
    List<GameObject> prevMenus = new ();
    // Start is called before the first frame update
    void Awake()
    {
        if (manager == null)
        {
            manager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        MainMenu();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void PlayScene (int scene = 0)
    {
        SceneManager.LoadScene(scene);
        Resume();
    }

    public void Pause()
    {
        if (!prevMenus[0].activeInHierarchy)
        {
            SetMenu(pauseMenu);
            Time.timeScale = 0;
        }
    }

    public void MainMenu ()
    {
        SetMenu(mainMenu);
        SceneManager.LoadScene(0);
    }

    public void Resume()
    {
        CloseCurrentMenu();
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void CloseCurrentMenu()
    {
        if (prevMenus.Count > 0)
        {
            var currentMenu = prevMenus[0];
            currentMenu.SetActive(false);
        }
    }

    public void SetMenu (GameObject menu)
    {
        CloseCurrentMenu();
        menu.SetActive(true);
        prevMenus.Insert(0, menu);
    }

    public void Back ()
    {
        var prevMenu = prevMenus[1];
        prevMenu.SetActive(true);

        var currentMenu = prevMenus[0];
        currentMenu.SetActive(false);
        prevMenus.Remove(currentMenu);
    }
}

