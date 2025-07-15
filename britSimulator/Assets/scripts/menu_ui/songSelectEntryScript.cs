using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class songSelectEntryScript : MonoBehaviour
{
    public void isClickedOn()
    {
        songSelectScript script = GameObject.Find("scriptManager").GetComponent<songSelectScript>();
        script.selectSong(gameObject);
    }
}
