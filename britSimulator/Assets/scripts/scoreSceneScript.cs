using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreSceneScript : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI song;



    void Start()
    {
        score.text = inventoryScript.score.ToString();
        song.text = gameManagerScript.song;
    }
}
