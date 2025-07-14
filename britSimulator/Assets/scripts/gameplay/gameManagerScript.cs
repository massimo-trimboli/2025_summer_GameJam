using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class gameManagerScript : MonoBehaviour
{
    public Transform spawnPoint;
    public Vector3 launchVelocity;

    public GameObject arm;
    public GameObject leg;

    public GameObject[] ingredients;

    public static GameObject objectInTrigger;




    void Start()
    {
        deSpawnOriginalIngredients();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            summonIngredients(0);
        }
    }

    void deSpawnOriginalIngredients()
    {
        foreach(GameObject obj in ingredients)
        {
            obj.SetActive(false);
        }
    }


    void summonIngredients(int i)
    {
        GameObject obj = GameObject.Instantiate(ingredients[i], spawnPoint.position, spawnPoint.rotation);
        obj.SetActive(true);
        obj.AddComponent<Rigidbody2D>();
        obj.GetComponent<Rigidbody2D>().velocity = launchVelocity;
    }

    public void useArm()
    {
        //turn off first to reset animation
        arm.SetActive(false);
        //leg.SetActive(false);

        // reset interactions
        arm.GetComponent<limbScript>().interactedOnce = false;
        //leg.GetComponent<limbScript>().interactedOnce = false;

        arm.SetActive(true);
    }
    public void useLeg()
    {
        //turn off first to reset animation
        arm.SetActive(false);
        leg.SetActive(false);
        // reset interactions
        arm.GetComponent<limbScript>().interactedOnce = false;
        leg.GetComponent<limbScript>().interactedOnce = false;

        leg.SetActive(true);
    }

    public static void interact(GameObject limb)
    {
        if(objectInTrigger != null)
        {
            //make sure you dont grab multiple things
            limb.GetComponent<limbScript>().interactedOnce = true;

            if (limb.GetComponent<limbScript>().isArm)
            {
                //grab if is arm
                limb.GetComponent<limbScript>().interactedOnce = true;
                Destroy(objectInTrigger);

            }
            else if (limb.GetComponent<limbScript>().isLeg)
            {
                //kick if is leg
            }
        }
    }
}
