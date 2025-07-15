using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreSceneScript : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI song;
    public GameObject failure;



    void Start()
    {
        score.text = inventoryScript.score.ToString();
        song.text = gameManagerScript.song;
        if(inventoryScript.score <= 0)
        {
            failure.SetActive(true);
        }
        else
        {
            failure.SetActive(false);
        }
    }
}
