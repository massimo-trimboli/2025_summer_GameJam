using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManagerScript : MonoBehaviour
{
    public Transform spawnPoint;
    public Vector3 launchVelocity;

    public GameObject[] ingredients;

    public GameObject background;



    void Start()
    {
        //darken background
        float darkness = 0.45f;
        Color darkerColor = new Color(darkness, darkness, darkness, 1f);
        background.GetComponent<SpriteRenderer>().color = darkerColor;

        deSpawnOriginals();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            print("click");
            summon(0);
        }
    }

    void deSpawnOriginals()
    {
        foreach(GameObject obj in ingredients)
        {
            obj.SetActive(false);
        }
    }


    void summon(int i)
    {
        GameObject obj = GameObject.Instantiate(ingredients[i], spawnPoint.position, spawnPoint.rotation);
        obj.SetActive(true);
        obj.AddComponent<Rigidbody2D>();
        obj.GetComponent<Rigidbody2D>().velocity = launchVelocity;
    }
}
