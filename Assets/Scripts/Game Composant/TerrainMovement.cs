using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainMovement : MonoBehaviour
{
    public float speed;
    private GameObject player;

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (!player.GetComponent<Player>().isFighting)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -speed);
        }
        else
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
       
    }
}
