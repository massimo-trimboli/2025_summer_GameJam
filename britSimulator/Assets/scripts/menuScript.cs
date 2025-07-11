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
        SceneManager.LoadScene("menu");
    }

    public void viewCredits()
    {

    }

    public void openPortfolio()
    {
        Application.OpenURL("https://massimo-trimboli.itch.io/");
    }
}
