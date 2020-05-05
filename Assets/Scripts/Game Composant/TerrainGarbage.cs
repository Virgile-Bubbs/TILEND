using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGarbage : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "End")
        {
            Destroy(other.transform.parent.gameObject);
        }
    }
}
