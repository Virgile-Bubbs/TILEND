using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody rb;
    private float speed;

    public int level;
    public int health;
    public int maxHealth;
    public int strenght;
    public int exp;

    public GameObject healthBar;
    private Constantes constantes;

    // Start is called before the first frame update
    void Start()
    {
        constantes = GameObject.FindWithTag("Constante").GetComponent<Constantes>();
        rb = GetComponent<Rigidbody>();
        speed = 0.08f;

        level = constantes.current_enemy_level;
        maxHealth = constantes.current_enemy_maxHealth;
        health = maxHealth;
        strenght = constantes.current_enemy_strenght;
        exp = constantes.current_enemy_exp;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -0.1)
        {
            transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > 0.1)
        {
            transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
        }
       
    }
}
