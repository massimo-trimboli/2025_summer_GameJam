using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class inventoryScript : MonoBehaviour
{
    //order: cup, leaves, kettle, milk
    public GameObject[] uiIngredients;
    public TextMeshProUGUI scoreText;
    public int score = 0;

    bool hasCup;
    bool hasLeaves;
    bool hasKettle;
    bool hasMilk;



    // Start is called before the first frame update
    void Start()
    {
        resetIngredients();
        scoreText.text = "score: 0";
    }

    void resetIngredients()
    {
        hasCup = false;
        hasLeaves = false;
        hasKettle = false;
        hasMilk = false;

        foreach(GameObject ingredient in uiIngredients)
        {
            ingredient.SetActive(false);
        }
    }

    public void itemKicked()
    {
        addToScore(50);
    }
    public void itemGrabbed()
    {
        addToScore(50);
    }

    void addToScore(int gain)
    {
        score += gain;
        scoreText.text = "score: " + score;
    }
}
