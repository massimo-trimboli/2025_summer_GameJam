using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class gameManagerScript : MonoBehaviour
{
    public Transform spawnPoint;
    public Vector3 launchVelocity;

    public GameObject arm;
    public GameObject leg;

    public GameObject[] ingredients;

    public Vector3 kickLaunchVelocity;
    public static Vector3 kickLaunchVelocityStatic;

    public static GameObject objectInTrigger;

    public static string song = "rule britania";
    public GameObject[] songList;




    void Start()
    {
        loadSong();
        kickLaunchVelocityStatic = kickLaunchVelocity;

        deSpawnOriginalIngredients();
        print(song);
        print(inventoryScript.score);
    }

    // Update is called once per frame
    void Update()
    {        
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int i = Random.Range(0, ingredients.Length);
            //summonIngredients(i);
            summonRandom();
        }
        */

        if(inventoryScript.score < -300)
        {
            nextScene();
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
        //not during tea time
        if (/* !GetComponent<inventoryScript>().teaTimeGroup.activeSelf */ true)
        {
            GameObject obj = GameObject.Instantiate(ingredients[i], spawnPoint.position, spawnPoint.rotation);
            obj.SetActive(true);
            obj.AddComponent<Rigidbody2D>();
            obj.GetComponent<Rigidbody2D>().velocity = launchVelocity;
        }
    }
    public void summonRandom()
    {
        int i = Random.Range(0, ingredients.Length);
        summonIngredients(i);
    }

    public void useArm()
    {
        //turn off first to reset animation
        arm.SetActive(false);
        leg.SetActive(false);

        // reset interactions
        arm.GetComponent<limbScript>().interactedOnce = false;
        leg.GetComponent<limbScript>().interactedOnce = false;

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

    public void interact(GameObject limb)
    {
        if(objectInTrigger != null)
        {
            //make sure you dont grab multiple things
            limb.GetComponent<limbScript>().interactedOnce = true;

            if (limb.GetComponent<limbScript>().isArm)
            {
                //manage inventory
                string item = objectInTrigger.GetComponent<ingredientScript>().itemName;
                GetComponent<inventoryScript>().itemGrabbed(item);

                //grab if is arm
                limb.GetComponent<limbScript>().interactedOnce = true;
                Destroy(objectInTrigger);

            }
            else if (limb.GetComponent<limbScript>().isLeg)
            {
                //kick if is leg
                limb.GetComponent<limbScript>().interactedOnce = true;
                objectInTrigger.GetComponent<Rigidbody2D>().velocity = kickLaunchVelocityStatic;
                //dissable collisions so it doesnt hit other ingredients
                objectInTrigger.GetComponent<BoxCollider2D>().isTrigger = true;
                //destroy - delayed so it happens offscreen
                objectInTrigger.GetComponent<ingredientScript>().kickOut();

                //add to score
                GetComponent<inventoryScript>().itemKicked();
            }
        }
    }

    void loadSong()
    {
        foreach(GameObject song in songList)
        {
            song.SetActive(false);
        }

        if(song == "god save the queen")
        {
            songList[0].SetActive(true);
        }
        else if(song == "rule britania")
        {
            songList[1].SetActive(true);
        }
    }

    public void nextScene()
    {
        SceneManager.LoadScene("score");
    }
}
