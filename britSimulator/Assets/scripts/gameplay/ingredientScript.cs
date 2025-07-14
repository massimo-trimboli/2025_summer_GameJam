using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ingredientScript : MonoBehaviour
{
    public string itemName = "milk";


    
    // send gameobjec
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "collider")
        {
            gameManagerScript.objectInTrigger = gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "collider")
        {
            gameManagerScript.objectInTrigger = null;
        }
    }


    //out of bounds / on miss
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "border")
        {
            Destroy(gameObject);
        }
    }
}
