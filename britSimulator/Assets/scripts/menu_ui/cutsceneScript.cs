using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class cutsceneScript : MonoBehaviour
{
    public GameObject scriptObject;

    public GameObject button1;
    public GameObject skipButton;

    // Start is called before the first frame update
    void Start()
    {
        VideoPlayer player = GetComponent<VideoPlayer>();
        player.loopPointReached += videoEnd;

        summonButton();
    }

    void videoEnd(VideoPlayer player)
    {
        nextScene();
    }
    public void nextScene()
    {
        //if first time watching
        if (PlayerPrefs.GetInt("firstTimeWatchingCutscene", 1) == 1)
        {
            PlayerPrefs.SetInt("firstTimeWatchingCutscene", 0);
        }

        //if first playthrough
        if (PlayerPrefs.GetInt("firstPlaythrough", 1) == 1)
        {
            scriptObject.GetComponent<menuScript>().goDoTutorial();
        }
        else
        {
            scriptObject.GetComponent<menuScript>().openSonglist();
        }
    }



    public void summonButton()
    {
        button1.SetActive(false);
        skipButton.SetActive(true);

        Invoke("unSummonButton", 3f);
    }

    void unSummonButton()
    {
        button1.SetActive(true);
        skipButton.SetActive(false);
    }
}
