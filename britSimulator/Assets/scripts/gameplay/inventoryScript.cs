using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class inventoryScript : MonoBehaviour
{
    //order: cup, leaves, kettle, milk
    public GameObject[] uiIngredients;
    public TextMeshProUGUI scoreText;
    public GameObject teaTimeGroup;

    public static long score = 0;
    double oldScore;
    //is set in song select screen, 0 is 1000000 by default
    public static int winCondition = 100000;
    long theHighScore;
    [SerializeField] Color beatHighScoreColor;

    bool hasCup;
    bool hasLeaves;
    bool hasKettle;
    bool hasMilk;



    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        resetIngredients();
        scoreText.text = "score: 0";

        theHighScore = long.Parse(PlayerPrefs.GetString(gameManagerScript.song, "0"));
    }

    void Update()
    {
        //color indicator
        if(score < winCondition)
        {
            scoreText.color = Color.red;
        }
        else
        {
            if(score > theHighScore && theHighScore > 0)
            {
                scoreText.color = beatHighScoreColor;
            }
            else
            {
                scoreText.color = Color.green;
            }
        }

        //gradualy increment score
        if(oldScore != score)
        {
            double difference = score - oldScore;
            long speedFrames = 45;
            double increment = difference / speedFrames;

            oldScore += increment;

            //+1 because it rounds down
            int sign=0;
            if (score>0){sign=1;}
            scoreText.text = "score: " + (((long)Math.Floor(oldScore) + sign).ToString());
        }
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
    public void itemGrabbed(string itemName)
    {
        if (hasCup)
        {
            if (itemName == "cup")
            {
                addToScore(-100);
                resetIngredients();
            }
            else if (itemName == "leaves")
            {
                if (!hasLeaves)
                {
                    addToScore(50);
                    hasLeaves = true;
                    uiIngredients[1].SetActive(true);
                }
                else
                {
                    addToScore(-100);
                    resetIngredients();
                }
            }
            else if(itemName == "kettle")
            {
                if (!hasKettle)
                {
                    addToScore(50);
                    hasKettle = true;
                    uiIngredients[2].SetActive(true);
                }
                else
                {
                    addToScore(-100);
                    resetIngredients();
                }
            }
            else if (itemName == "milk")
            {
                if (!hasMilk)
                {
                    addToScore(50);
                    hasMilk = true;
                    uiIngredients[3].SetActive(true);
                }
                else
                {
                    addToScore(-100);
                    resetIngredients();
                }
            }
        }
        else
        {
            //pickup cup
            if(itemName == "cup")
            {
                addToScore(50);
                hasCup = true;
                uiIngredients[0].SetActive(true);
            }
            else //drop ingredients if dont have cup
            {
                addToScore(-100);
            }
        }

        if(hasCup && hasLeaves && hasKettle && hasMilk)
        {
            teaTime();
            //tea time can kill you iff activate while score is negative
            if(score < 0)
            {
                score = 100;
            }
        }
    }

    public void addToScore(int gain)
    {
        score += gain;
        //scoreText.text = "score: " + score;
    }
    void teaTime()
    {
        score *= 2;
        resetIngredients();
        teaTimeGroup.SetActive(true);
    }
}
