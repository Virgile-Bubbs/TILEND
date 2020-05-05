using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainSpawner : MonoBehaviour
{
    public GameObject newGround;
    private bool spawned;

    private void Start()
    {
        spawned = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !spawned)
        {
            Instantiate(newGround, new Vector3(0, 0, 100), Quaternion.identity);
        }
        spawned = true;
    }
}
