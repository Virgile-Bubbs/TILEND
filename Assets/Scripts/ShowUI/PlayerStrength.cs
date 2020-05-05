using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStrength : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = "Force : " + player.GetComponent<Player>().strenght;
    }
}
