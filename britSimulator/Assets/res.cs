using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class res : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1080, FullScreenMode.FullScreenWindow);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Screen.SetResolution(1920,1080, FullScreenMode.FullScreenWindow);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Screen.SetResolution(1920, 823, FullScreenMode.FullScreenWindow);
        }
        */
    }
}
