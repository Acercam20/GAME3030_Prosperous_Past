using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZoneBehaviour : MonoBehaviour
{
    GameManager gameManager;
    private void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().isMoveable = false;
            other.gameObject.transform.position = gameManager.playerRespawnLocation;
            //other.gameObject.GetComponent<PlayerController>().isMoveable = true;

            //Debug.Log("Kill Zone Hit");
        }
        else if (other.gameObject.tag == "PushableObject")
        {
            other.gameObject.transform.parent = null;
            other.gameObject.transform.position = gameManager.rockRespawnLocation;
            other.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            other.gameObject.GetComponent<BoxCollider>().isTrigger = false;
        }
        else
        {
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().isMoveable = true;
        }
    }
}
