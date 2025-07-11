using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class goDoTutoScript : MonoBehaviour
{
    public int timer;
    public TextMeshProUGUI counter;

    public GameObject objectsToRemove;
    public GameObject objectsToSummon;
    public GameObject backGround;
    public GameObject exclamation;



    void Start()
    {
        if(gameObject.name != "exclamation")
        {
            counter.text = timer.ToString();
            Invoke("countdown", 1f);
        }
    }

    void countdown()
    {
        if(timer > 0)
        {
            timer--;
            counter.text = timer.ToString();
            Invoke("countdown", 1f);
        }
        else
        {
            Destroy(objectsToRemove);

            exclamation.SetActive(true);
        }
    }

    public void hellFire()
    {
        Destroy(exclamation);
        backGround.GetComponent<SpriteRenderer>().color = Color.white;
        backGround.GetComponent<AudioSource>().enabled = true;
        objectsToSummon.SetActive(true);
    }
}
