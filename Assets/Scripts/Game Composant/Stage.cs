using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stage : MonoBehaviour
{
    public int level;
    private Constantes constantes;

    // Start is called before the first frame update
    void Start()
    {
        constantes = GameObject.FindWithTag("Constante").GetComponent<Constantes>();
        level = constantes.stage;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = "Stage " + level;
    }

    public void StageUp()
    {
        level++;
        constantes.stage = level;

        constantes.current_enemy_level = level;
        constantes.current_enemy_maxHealth = Mathf.RoundToInt(constantes.current_enemy_maxHealth * constantes.coeff);
        constantes.current_enemy_strenght = Mathf.RoundToInt(constantes.current_enemy_strenght * constantes.coeff);
        constantes.current_enemy_exp = Mathf.RoundToInt(constantes.current_enemy_exp * constantes.coeff);

        if(level % 10 == 0)
        {
            constantes.SaveEnemyStats();
            constantes.SaveGame();
        }
    }
}
