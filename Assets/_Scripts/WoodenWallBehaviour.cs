using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenWallBehaviour : MonoBehaviour
{
    public int maxHealth = 1;
    int health;
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PushableObject")
        {
            ReduceHealth();
        }
    }

    void ReduceHealth()
    {
        health--;
        gameObject.GetComponent<MeshRenderer>().material.color = new Color(gameObject.GetComponent<MeshRenderer>().material.color.r, gameObject.GetComponent<MeshRenderer>().material.color.g, gameObject.GetComponent<MeshRenderer>().material.color.b, 0.25f);
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }
}
