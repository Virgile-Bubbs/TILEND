using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        GetComponent<UnityEngine.UI.Image>().fillAmount = player.GetComponent<Player>().health / (float)player.GetComponent<Player>().maxHealth;
    }
}
