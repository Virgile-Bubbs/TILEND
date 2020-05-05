using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Niveau : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = "Niveau " + player.GetComponent<Player>().level;
    }
}
