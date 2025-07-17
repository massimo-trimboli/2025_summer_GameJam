using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseScript : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool gamePaused;



    void Start()
    {
        gamePaused = false;
        pauseMenu.SetActive(false);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            togglePause();
        }
    }

    public void togglePause()
    {
        if (!gamePaused)
        {
            gamePaused = true;
            pauseMenu.SetActive(true);

            Time.timeScale = 0;
        }
        else
        {
            gamePaused = false;
            pauseMenu.SetActive(false);

            Time.timeScale = 1;
        }
    }
    public void restart()
    {
        gamePaused = false;
        pauseMenu.SetActive(false);

        Time.timeScale = 1;

        SceneManager.LoadScene("game");
    }
}
