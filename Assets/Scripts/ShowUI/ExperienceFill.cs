using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceFill : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        GetComponent<UnityEngine.UI.Image>().fillAmount = (float) player.GetComponent<Player>().exp / player.GetComponent<Player>().expMax;
    }
}
