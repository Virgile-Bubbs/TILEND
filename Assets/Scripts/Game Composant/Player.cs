using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public int level;
    public int health;
    public int maxHealth;
    public int strenght;
    public int expMax;
    public int exp;
    public int goldGain;

    public bool isFighting;
    private Constantes constantes;

    private void Start()
    {
        constantes = GameObject.FindWithTag("Constante").GetComponent<Constantes>();

        level = constantes.player_level;
        maxHealth = constantes.player_maxHealth;
        health = maxHealth;
        strenght = constantes.player_strenght;
        expMax = constantes.player_expMax;
        exp = constantes.player_exp;
        goldGain = constantes.player_goldGain;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            isFighting = true;
            gameObject.GetComponent<Fight>().CreateFight(other.gameObject);
        }
    }

}   
