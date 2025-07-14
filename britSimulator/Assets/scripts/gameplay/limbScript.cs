using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class limbScript : MonoBehaviour
{
    //these are set in the animation itself
    public bool isActive;
    public bool turnOff;

    //make sure you dont grab multiple things
    public bool interactedOnce;

    public bool isArm;
    public bool isLeg;




    // Update is called once per frame
    void Update()
    {
        if (turnOff)
        {
            gameObject.SetActive(false);
        }

        if (isActive && !interactedOnce)
        {
            gameManagerScript.interact(gameObject);
        }

        print("isActive: " + isActive);
    }
}
