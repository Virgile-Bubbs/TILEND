using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            System.Random rand = new System.Random();
            int r = rand.Next(4);
           
            if(r == 0)
            {
                Instantiate(enemy, transform.position, Quaternion.identity);
            }
            
        }
    }
}
