using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class firstPlaythrough : MonoBehaviour
{
    [SerializeField] GameObject menuScreenTutorialButton;
    [SerializeField] TextMeshProUGUI versionText;
    [SerializeField] GameObject cutSceneButton;


    void Start()
    {
        if (SceneManager.GetActiveScene().name == "menu")
        {
            versionText.text = Application.version.ToString();
        }


        //PlayerPrefs.DeleteAll();
        if (PlayerPrefs.GetInt("firstPlaythrough", 1) == 1)
        {
            if (SceneManager.GetActiveScene().name == "menu")
            {
                Destroy(menuScreenTutorialButton);
            }
        }
        if (SceneManager.GetActiveScene().name == "cutScene")
        {
            if(PlayerPrefs.GetInt("firstTimeWatchingCutscene", 1) == 1)
            {
                Destroy(cutSceneButton);
            }
        }
    }
}
