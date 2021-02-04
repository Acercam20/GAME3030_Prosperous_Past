using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneTabletBehaviour : MonoBehaviour
{
    public bool playerInRange = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().StoneTabletHUD.SetActive(true);
        //Activate A Message on canvas through gamemanager
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().StoneTabletHUD.SetActive(false);
        //Deactivate A Message on canvas through gamemanager
    }
}
