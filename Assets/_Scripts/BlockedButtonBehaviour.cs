using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockedButtonBehaviour : MonoBehaviour
{
    public List<GameObject> manaLines;
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
        {
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().SetInteractionText("Press E to interact");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().SetInteractionText("");
        }
    }

    public void Activate(bool active)
    {
        if (active)
        {
            gameObject.GetComponent<MeshRenderer>().material = GameObject.FindWithTag("GameManager").GetComponent<GameManager>().activatedTotemMat;
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().FinishObjectiveFour(true);
            for (int i = 0; i < manaLines.Count; i++)
            {
                manaLines[i].GetComponent<MeshRenderer>().material = GameObject.FindWithTag("GameManager").GetComponent<GameManager>().activatedTotemMat;
            }
        }
        else
            gameObject.GetComponent<MeshRenderer>().material = GameObject.FindWithTag("GameManager").GetComponent<GameManager>().deactivatedTotemMat;
    }
}
