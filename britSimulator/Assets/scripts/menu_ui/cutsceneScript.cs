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
        player.loopPointReached += nextScene;

        button1.SetActive(true);
        skipButton.SetActive(false);
    }

    void nextScene(VideoPlayer player)
    {
        scriptObject.GetComponent<menuScript>().goDoTutorial();
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
