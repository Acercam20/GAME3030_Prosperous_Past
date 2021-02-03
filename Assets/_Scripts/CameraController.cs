using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float distanceBehindPlayer = 10;
    public float distanceAbovePlayer = 5;
    private int x, y, z;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        x = (int)(player.transform.position.x + distanceBehindPlayer);
        y = (int)(player.transform.position.y + distanceAbovePlayer);
        z = (int)player.transform.position.z;
        transform.position = new Vector3(x, y, z);
    }
}
