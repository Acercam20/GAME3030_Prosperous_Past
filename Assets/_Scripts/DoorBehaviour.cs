using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    public bool IsDoubleDoor;
    public GameObject door1;
    public GameObject door2;
    private bool isOpening = false;
    private bool isOpen = false;

    void Update()
    {
        if (isOpening)
        {
            if (door1.transform.rotation.eulerAngles.y > 180)
            {
                Vector3 rotateV1 = new Vector3(0, -1, 0);
                door1.transform.Rotate(rotateV1, 0.8f);
            }
            if (door2.transform.rotation.eulerAngles.y < 359)
            {
                Vector3 rotateV2 = new Vector3(0, 1, 0);
                door2.transform.Rotate(rotateV2, 0.8f);
            }
            else
            {
                door1.GetComponent<MeshCollider>().isTrigger = true;
                door2.GetComponent<MeshCollider>().isTrigger = true;
                isOpen = true;
            }
            if (door1.transform.localScale.x < 2)
            {
                door1.transform.localScale = new Vector3(door1.transform.localScale.x + 0.01f, 1, 1);
            }
            if (door2.transform.localScale.x > -2)
            {
                door2.transform.localScale = new Vector3(door2.transform.localScale.x - 0.01f, 1, 1);
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player" && !isOpen)
        {
            isOpening = true;
            GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>().PlaySound(GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>().doorOpening);
        }
    }

    void OpenDoor()
    {
        //Quaternion rotateQ1 = Quaternion.Euler(0, door1.transform.rotation.y * Time.deltaTime, 0);
        
        if (IsDoubleDoor)
        {
            //Quaternion rotateQ2 = Quaternion.Euler(0, door2.transform.rotation.y * -Time.deltaTime, 0);
           
            //door1.transform.rotation = rotateQ1;
            
            //door2.transform.rotation = rotateQ2;
        }
        else
        {
            //door1.transform.rotation = rotateQ1;
        }
    }
}
