using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    public bool IsDoubleDoor;
    public GameObject door1;
    public GameObject door2;

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            OpenDoor();
        }
    }

    void OpenDoor()
    {
        Quaternion rotateQ1 = Quaternion.Euler(0, -60, 0);
        if (IsDoubleDoor)
        {
            Quaternion rotateQ2 = Quaternion.Euler(0, 60, 0);
            door1.transform.rotation = rotateQ1;
            door2.transform.rotation = rotateQ2;
        }
        else
        {
            door1.transform.rotation = rotateQ1;
        }
    }
}
