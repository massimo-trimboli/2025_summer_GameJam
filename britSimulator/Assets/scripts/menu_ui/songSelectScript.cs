using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class songSelectScript : MonoBehaviour
{
    public TMP_Dropdown dropdown;



    public void getsong()
    {
        int i = dropdown.value;
        gameManagerScript.song = dropdown.options[i].text;
    }
}
