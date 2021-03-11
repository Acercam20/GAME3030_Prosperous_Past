using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetraUIButtons : MonoBehaviour
{
    public GameObject associatedWorldObject;
    void Start()
    {
        
    }

    public void OnButtonPressed()
    {
        associatedWorldObject.GetComponent<TetraButtonsBehaviour>().Activate();
    }
}
