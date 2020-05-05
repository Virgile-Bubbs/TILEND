using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndStage : MonoBehaviour
{
    public GameObject stage;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            stage.GetComponent<Stage>().StageUp();
        }
    }
}
