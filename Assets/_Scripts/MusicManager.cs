using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public AudioClip menuBGM;
    public AudioClip gameBGM;
    private bool levelCheck;
    void Start()
    {
        DontDestroyOnLoad(this);
        if (GameObject.FindGameObjectsWithTag("MusicManager").Length > 1)
        {
            for (int i = 1; i < GameObject.FindGameObjectsWithTag("MusicManager").Length; i++)
            {
                Destroy(GameObject.FindGameObjectsWithTag("MusicManager")[i]);
            }
            //GameObject.FindGameObjectsWithTag("BGM")[1].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level 1" && levelCheck)
        {
            gameObject.GetComponent<AudioSource>().clip = gameBGM;
            gameObject.GetComponent<AudioSource>().Play();
            levelCheck = false;
        }
        else if (!(SceneManager.GetActiveScene().name == "Level 1") && !levelCheck)
        {
            gameObject.GetComponent<AudioSource>().clip = menuBGM;
            gameObject.GetComponent<AudioSource>().Play();
            levelCheck = true;
        }
    }
}
