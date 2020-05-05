using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyHealth : MonoBehaviour
{
    public GameObject enemy;

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = enemy.GetComponent<Enemy>().health + "/" + enemy.GetComponent<Enemy>().maxHealth;
    }
}
