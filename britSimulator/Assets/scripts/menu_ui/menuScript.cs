using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour
{
    
    public void launchCutscene()
    {
        SceneManager.LoadScene("cutScene");
    }

    public void launchGame()
    {
        SceneManager.LoadScene("game");
    }

    public void openSonglist()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("songlist");
    }

    public void goDoTutorial()
    {
        SceneManager.LoadScene("goDoTutorial");
    }

    public void openTutorial()
    {
        SceneManager.LoadScene("tutorial");
    }
    public void openMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("menu");
    }

    public void viewCredits()
    {
        SceneManager.LoadScene("credits");
    }

    public void openPortfolio()
    {
        Application.OpenURL("https://massimo-trimboli.itch.io/");
    }
}
