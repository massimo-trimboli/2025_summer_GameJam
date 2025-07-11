using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exclamationScript : MonoBehaviour
{
    public bool summonHell = false;
    public GameObject scriptManager;

    void Update()
    {
        if (summonHell)
        {
            summonHell = false;
            scriptManager.GetComponent<goDoTutoScript>().hellFire();
        }
    }
}
