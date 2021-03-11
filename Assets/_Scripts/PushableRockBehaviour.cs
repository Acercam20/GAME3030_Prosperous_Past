using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableRockBehaviour : MonoBehaviour
{
    public int sideNumber;
    public bool isBeingPushed;
    public float pushSpeed;
    public GameObject mesh;
    void Start()
    {
        
    }

    void Update()
    {
        /*
        if (isBeingPushed)
        {
            MoveRock();
        }
        UpdateHitbox();*/
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            //MoveRock(other.gameObject);
        }
        else if (other.gameObject.tag == "Kill Zone")
        {
            //Respawn
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            isBeingPushed = false;
        }
    }

    public void MoveRock(GameObject pushingObject)
    {
        
        /*
        if (sideNumber == 1)
        {
            transform.parent.position = new Vector3(transform.parent.position.x, transform.parent.position.y, transform.parent.position.z + (Time.deltaTime * pushSpeed)); //Time.deltaTime
            // +z
        }
        else if (sideNumber == 2)
        {
            transform.parent.position = new Vector3(transform.parent.position.x + (Time.deltaTime * pushSpeed), transform.parent.position.y, transform.parent.position.z);
            // +x
        }
        else if (sideNumber == 3)
        {
            transform.parent.position = new Vector3(transform.parent.position.x, transform.parent.position.y, transform.parent.position.z - (Time.deltaTime * pushSpeed));
            // -z
        }
        else if (sideNumber == 4)
        {
            transform.parent.position = new Vector3(transform.parent.position.x - (Time.deltaTime * pushSpeed), transform.parent.position.y, transform.parent.position.z);
            // -x
        }
        else
        {
            Debug.Log("No side number assigned");
        }*/
    }
    /*
    void UpdateHitbox()
    {
        if (sideNumber == 1)
        {
            gameObject.transform.position = new Vector3(mesh.transform.position.x, mesh.transform.position.y, mesh.transform.position.z + 1);
        }
        else if (sideNumber == 2)
        {
            gameObject.transform.position = new Vector3(mesh.transform.position.x + 1, mesh.transform.position.y, mesh.transform.position.z);
        }
        else if (sideNumber == 3)
        {
            gameObject.transform.position = new Vector3(mesh.transform.position.x, mesh.transform.position.y, mesh.transform.position.z - 1);
        }
        else if (sideNumber == 4)
        {
            gameObject.transform.position = new Vector3(mesh.transform.position.x - 1, mesh.transform.position.y, mesh.transform.position.z);
        }
    }*/
}
