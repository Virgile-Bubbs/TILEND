using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constantes : MonoBehaviour
{
    public int stage;
    public float coeff;

    public int enemy_level;
    public int enemy_maxHealth;
    public int enemy_health;
    public int enemy_strenght;
    public int enemy_exp;

    public int current_enemy_level;
    public int current_enemy_maxHealth;
    public int current_enemy_health;
    public int current_enemy_strenght;
    public int current_enemy_exp;

    public int player_level;
    public int player_maxHealth;
    public int player_health;
    public int player_strenght;
    public int player_expMax;
    public int player_exp;
    public int player_goldGain;

    private void Awake()
    {
        if(PlayerPrefs.GetInt("new_game") == 1)
        {
            NewGameSauvegarde();
            PlayerPrefs.SetInt("new_game", 0);
        }
        LoadGame();
    }

    public void NewGameSauvegarde()
    {
        PlayerPrefs.SetInt("stage", 1);
        PlayerPrefs.SetFloat("coeff", 1.5f);

        PlayerPrefs.SetInt("enemy_level", PlayerPrefs.GetInt("stage"));
        PlayerPrefs.SetInt("enemy_maxHealth", 7);
        PlayerPrefs.SetInt("enemy_strenght", 2);
        PlayerPrefs.SetInt("enemy_exp", 4);

        PlayerPrefs.SetInt("player_level", 1);
        PlayerPrefs.SetInt("player_maxHealth", 6);
        PlayerPrefs.SetInt("player_strenght", 2);
        PlayerPrefs.SetInt("player_expMax", 20);
        PlayerPrefs.SetInt("player_exp", 0);
        PlayerPrefs.SetInt("player_goldGain", 0); 
    }

    public void LoadGame()
    {
        stage = PlayerPrefs.GetInt("stage");
        coeff = PlayerPrefs.GetFloat("coeff");

        enemy_level = PlayerPrefs.GetInt("enemy_level");
        enemy_maxHealth = PlayerPrefs.GetInt("enemy_maxHealth");
        enemy_health = enemy_maxHealth;
        enemy_strenght = PlayerPrefs.GetInt("enemy_strenght");
        enemy_exp = PlayerPrefs.GetInt("enemy_exp");

        current_enemy_level = enemy_level;
        current_enemy_maxHealth = enemy_maxHealth;
        current_enemy_health = current_enemy_maxHealth;
        current_enemy_strenght = enemy_strenght;
        current_enemy_exp = enemy_exp;

        player_level = PlayerPrefs.GetInt("player_level");
        player_maxHealth = PlayerPrefs.GetInt("player_maxHealth");
        player_strenght = PlayerPrefs.GetInt("player_strenght");
        player_expMax = PlayerPrefs.GetInt("player_expMax");
        player_exp = PlayerPrefs.GetInt("player_exp");
        player_goldGain = PlayerPrefs.GetInt("player_goldGain");
    }

    public void SaveGame()
    {
        int stage_down = stage - (stage % 10);
        if(stage_down == 0)
        {
            stage_down = 1;
        }
        PlayerPrefs.SetInt("stage", stage_down);
        PlayerPrefs.SetFloat("coeff", coeff);

        PlayerPrefs.SetInt("enemy_level", stage_down);
        PlayerPrefs.SetInt("enemy_maxHealth", enemy_maxHealth);
        PlayerPrefs.SetInt("enemy_strenght", enemy_strenght);
        PlayerPrefs.SetInt("enemy_exp", enemy_exp);

        PlayerPrefs.SetInt("player_level", player_level);
        PlayerPrefs.SetInt("player_maxHealth", player_maxHealth);
        PlayerPrefs.SetInt("player_strenght", player_strenght);
        PlayerPrefs.SetInt("player_expMax", player_expMax);
        PlayerPrefs.SetInt("player_exp", player_exp);
        PlayerPrefs.SetInt("player_goldGain", player_goldGain);
    }

    public void SaveEnemyStats()
    {
        enemy_level = current_enemy_level;
        enemy_maxHealth = current_enemy_maxHealth;
        enemy_strenght = current_enemy_strenght;
        enemy_exp = current_enemy_exp;

        PlayerPrefs.SetInt("enemy_level", enemy_level);
        PlayerPrefs.SetInt("enemy_maxHealth", enemy_maxHealth);
        PlayerPrefs.SetInt("enemy_strenght", enemy_strenght);
        PlayerPrefs.SetInt("enemy_exp", enemy_exp);
        
    }
}
