using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class scoreSceneScript : MonoBehaviour
{
    public TextMeshProUGUI song;
    public TextMeshProUGUI score;
    public TextMeshProUGUI highScore;
    public GameObject failure;

    int restartHold;



    void Start()
    {
        score.text = inventoryScript.score.ToString();
        song.text = gameManagerScript.song;
        if(inventoryScript.score < inventoryScript.winCondition)
        {
            failure.SetActive(true);
        }
        else
        {
            failure.SetActive(false);
        }

        getHighScore();
    }

    void getHighScore()
    {
        //simple save system
        long theHighScore = long.Parse(PlayerPrefs.GetString(gameManagerScript.song, "0"));
        
        if(inventoryScript.score > theHighScore)
        {
            highScore.text = "new High Score";
            PlayerPrefs.SetString(gameManagerScript.song, inventoryScript.score.ToString());
        }
        else
        {
            highScore.text = theHighScore.ToString();
        }
    }

    private void Update()
    {
        //hold to restart
        if (Input.GetKey(KeyCode.R))
        {
            restartHold++;
            if (restartHold > 59)
            {
                SceneManager.LoadScene("game");
            }
        }
        else if (Input.GetKeyUp(KeyCode.R))
        {
            restartHold = 0;
        }
    }
}
