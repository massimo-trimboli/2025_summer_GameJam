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
        }
    }

    public void addToScore(int gain)
    {
        score += gain;
        scoreText.text = "score: " + score;
    }
    void teaTime()
    {
        score *= 2;
        scoreText.text = "score: " + score;
        resetIngredients();
        teaTimeGroup.SetActive(true);
    }
}
