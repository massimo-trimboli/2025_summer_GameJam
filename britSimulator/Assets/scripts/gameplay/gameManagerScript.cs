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

    public static string song = "kibo no hikari";
    public GameObject[] songList;

    int restartHold;

    public static bool isOnMobile = true;




    void Start()
    {
        loadSong();
        kickLaunchVelocityStatic = kickLaunchVelocity;

        deSpawnOriginalIngredients();
        print(inventoryScript.score);
    }

    // Update is called once per frame
    void Update()
    {
        if (inventoryScript.score < -300)
        {
            //inventoryScript.score = 0;
            nextScene();
        }
        //hold to restart
        if (Input.GetKey(KeyCode.R))
        {
            restartHold++;
            if (restartHold > 59)
            {
                SceneManager.LoadScene("game");
            }
        }
        else if(Input.GetKeyUp(KeyCode.R))
        {
            restartHold = 0;
        }

        if (!isOnMobile)
        {
            if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.F))
            {
                useArm();
            }
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.K))
            {
                useLeg();
            }
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
        else if (song == "yma o hyd")
        {
            songList[2].SetActive(true);
        }
        else if (song == "sosban fach")
        {
            songList[3].SetActive(true);
        }
        else if (song == "rise! rise!")
        {
            songList[4].SetActive(true);
        }
        else if (song == "chi mi na morbheanna")
        {
            songList[5].SetActive(true);
        }
        else if (song == "ireland's call")
        {
            songList[6].SetActive(true);
        }
        else if (song == "the foggy dew")
        {
            songList[7].SetActive(true);
        }
        else if (song == "come out ye black and tans")
        {
            songList[8].SetActive(true);
        }
        else if (song == "erika")
        {
            songList[9].SetActive(true);
        }
        else if (song == "bella ciao")
        {
            songList[10].SetActive(true);
        }
        else if (song == "funiculi funicula")
        {
            songList[11].SetActive(true);
        }
        else if (song == "sakura sakura")
        {
            songList[12].SetActive(true);
        }
        else if (song == "kibo no hikari")
        {
            songList[13].SetActive(true);
        }
        else
        {
            SceneManager.LoadScene("songlist");
        }
    }

    public void nextScene()
    {
        SceneManager.LoadScene("score");
    }
}
