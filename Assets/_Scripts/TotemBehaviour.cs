using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotemBehaviour : MonoBehaviour
{
    public bool Activated;
    public int ID;

    public void Deactivate()
    {
        gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().material = GameObject.FindWithTag("GameManager").GetComponent<GameManager>().deactivatedTotemMat;
        Activated = false;
    }

    public void Activate()
    {
        if (!Activated)
        {
            gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().material = GameObject.FindWithTag("GameManager").GetComponent<GameManager>().activatedTotemMat;
            Activated = true;
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().ActivateTotem(ID);
        }
    }
}
