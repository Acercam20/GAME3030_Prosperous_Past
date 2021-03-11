using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateBehaviour : MonoBehaviour
{
    public bool isActive;
    public bool isEast;
    public List<GameObject> ManaLines;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "PushableObject")
        {
            isActive = true;

            for (int i = 0; i < ManaLines.Count; i++)
            {
                ManaLines[i].GetComponent<MeshRenderer>().material = GameObject.FindWithTag("GameManager").GetComponent<GameManager>().activatedTotemMat;
            }

            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().ActivatePressurePlate(isActive, isEast);
            Debug.Log("Activated!");
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "PushableObject")
        {
            if (!GameObject.FindWithTag("GameManager").GetComponent<GameManager>().pressurePlateChallengeComplete)
            {
                isActive = false;

                for (int i = 0; i < ManaLines.Count; i++)
                {
                    ManaLines[i].GetComponent<MeshRenderer>().material = GameObject.FindWithTag("GameManager").GetComponent<GameManager>().deactivatedTotemMat;
                }

                GameObject.FindWithTag("GameManager").GetComponent<GameManager>().ActivatePressurePlate(isActive, isEast);
                Debug.Log("Deactivated!");
            }
        }
    }
}
