using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teaTimeAnimScript : MonoBehaviour
{
    public GameObject teaTime;
    public bool isfinished;
    void Update()
    {
        if (isfinished)
        {
            isfinished = false;
            teaTime.SetActive(false);
        }
    }
}
