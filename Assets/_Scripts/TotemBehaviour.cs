using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotemBehaviour : MonoBehaviour
{
    public bool Activated;
    public GameObject totemObject;
    public int ID;

    private void Start()
    {
        totemObject.GetComponent<ParticleSystem>().Stop();
    }

    public void Deactivate()
    {
        totemObject.GetComponent<ParticleSystem>().Stop();
        Activated = false;
    }

    public void Activate()
    {
        if (!Activated)
        {
            totemObject.GetComponent<ParticleSystem>().Play();
            Activated = true;
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().ActivateTotem(ID);
        }
    }
}
