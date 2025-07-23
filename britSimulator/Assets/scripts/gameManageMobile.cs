using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManageMobile : MonoBehaviour
{
    public GameObject mobileButtons;

    public GameObject[] pcText;
    public GameObject[] mobileText;


    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "game")
        {
            mobileButtons.SetActive(gameManagerScript.isOnMobile);
        }

        if (SceneManager.GetActiveScene().name == "tutorial")
        {
            if (gameManagerScript.isOnMobile)
            {
                foreach (GameObject text in pcText)
                {
                    text.SetActive(false);
                }
                foreach (GameObject text in mobileText)
                {
                    text.SetActive(true);
                }
            }
            else
            {
                foreach (GameObject text in mobileText)
                {
                    text.SetActive(false);
                }
                foreach (GameObject text in pcText)
                {
                    text.SetActive(true);
                }
            }
        }
    }
}
