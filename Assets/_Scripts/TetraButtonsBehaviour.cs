using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetraButtonsBehaviour : MonoBehaviour
{
    public GameObject leftButton, rightButton; //The buttons on either side
    public Material onMat, offMat;
    public int id;
    public bool isActive = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        Flip();
        rightButton.GetComponent<TetraButtonsBehaviour>().Flip();
        leftButton.GetComponent<TetraButtonsBehaviour>().Flip();
        GameObject.FindWithTag("GameManager").GetComponent<GameManager>().TetraBoolChecks();
    }

    public void Flip()
    {
        if (isActive)
        {
            isActive = false;
            gameObject.GetComponent<MeshRenderer>().material = offMat;
            //GameObject.FindWithTag("GameManager").GetComponent<GameManager>().tetraButtonBools[id - 1] = false;
        }
        else
        {
            isActive = true;
            gameObject.GetComponent<MeshRenderer>().material = onMat;
        }
    }
}
