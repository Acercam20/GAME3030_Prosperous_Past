using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneTabletBehaviour : MonoBehaviour
{
    public bool playerInRange = false;
    public bool isTetra = false;
    void Start()
    {
        //GameObject.FindWithTag("GameManager").GetComponent<GameManager>().StoneTabletHUD.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !isTetra)
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().StoneTabletHUD.SetActive(true);
        else if (other.gameObject.tag == "Player" && isTetra)
        {
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().TetraUI.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            GameObject.FindWithTag("Player").GetComponent<PlayerController>().cameraLock = true;
        }
        //Activate A Message on canvas through gamemanager
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && !isTetra)
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().StoneTabletHUD.SetActive(false);
        else if (other.gameObject.tag == "Player" && isTetra)
        {
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().TetraUI.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            GameObject.FindWithTag("Player").GetComponent<PlayerController>().cameraLock = false;
        }
        //Deactivate A Message on canvas through gamemanager
    }
}
