using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ExperienceText : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = player.GetComponent<Player>().exp + " / " + player.GetComponent<Player>().expMax;
    }
}
