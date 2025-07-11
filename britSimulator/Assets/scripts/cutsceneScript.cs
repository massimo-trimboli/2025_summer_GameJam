using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class cutsceneScript : MonoBehaviour
{
    public GameObject scriptObject;
    // Start is called before the first frame update
    void Start()
    {
        VideoPlayer player = GetComponent<VideoPlayer>();
        player.loopPointReached += nextScene;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void nextScene(VideoPlayer player)
    {
        scriptObject.GetComponent<menuScript>().goDoTutorial();
    }
}
