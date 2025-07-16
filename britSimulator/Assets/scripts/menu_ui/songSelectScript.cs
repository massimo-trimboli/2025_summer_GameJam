using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class songSelectScript : MonoBehaviour
{
    [Serializable] public class songListEntry
    {
        public string name;
        public Texture country;
        public int index;
    }

    public GameObject button;
    public float margin;
    public Color selectColor;
    [SerializeField] public songListEntry[] songList;

    private void Start()
    {
        makeList();
        selectSongOnStart();
    }

    void makeList()
    {
        button.SetActive(false);
        int loopCount = songList.Length - 1;

        for (int i = 0; i <= loopCount; i++)
        {
            songList[i].index = i;

            //instantiate
            GameObject button2 = Instantiate(button);
            button2.transform.parent = button.transform.parent;
            button2.transform.position = button.transform.position;
            button2.transform.localScale = button.transform.localScale;

            //set location
            button2.transform.position += new Vector3(0, -(margin * i), 0);

            //set name and country icon
            TextMeshProUGUI text = button2.transform.GetComponentInChildren<TextMeshProUGUI>();
            text.text = songList[i].name;
            RawImage flag = button2.transform.GetChild(1).GetComponent<RawImage>();
            print(flag);
            flag.texture = songList[i].country;

            button2.SetActive(true);
        }
    }

    public void selectSong(GameObject sender)
    {
        GameObject[] songs = GameObject.FindGameObjectsWithTag("song");
        for(int i = 0; i < songs.Length; i++)
        {
            songs[i].GetComponent<RawImage>().color = Color.white;
            if (songs[i] == sender)
            {
                songs[i].GetComponent<RawImage>().color = selectColor;
                gameManagerScript.song = songList[i].name;
            }
        }
    }
    void selectSongOnStart()
    {
        GameObject[] songs = GameObject.FindGameObjectsWithTag("song");
        selectSong(songs[0]);
    }
}
