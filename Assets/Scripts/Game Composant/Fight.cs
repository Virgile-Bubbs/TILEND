using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class Fight : MonoBehaviour
{
    private GameObject player;
    private GameObject enemy;

    public GameObject canvas;
    public GameObject slicer;
    public GameObject timer;
    public GameObject playerDamage;
    public GameObject playerHurt;

    private GameObject currentSlice;
    private GameObject currentTimer;
    private SwipeControls swipeControls;
    private Swipe currentSwipe;
    private GameObject currentPlayerDamage;

    private Constantes constantes;

    private void Start()
    {
        constantes = GameObject.FindWithTag("Constante").GetComponent<Constantes>();
    }

    private void Update()
    {
        if(GetComponent<Player>().isFighting)
        {
            if (GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>().end)
            {
                constantes.SaveGame();
                SceneManager.LoadScene("Stage");
            }

            if(swipeControls.swipeOK)
            {
                Attack();

                //On a battu l'enemy
                if (enemy.GetComponent<Enemy>().health <= 0)
                {
                    EnemyDie();

                    //MONTE DE NIVEAU
                    if (GetComponent<Player>().exp >= GetComponent<Player>().expMax)
                    {
                        LevelUp();
                    }
                }
                else
                {
                    ResetSlicer();
                }
                
            }

            else if (swipeControls.swipeERR)
            {
                swipeControls.swipeERR = false;
                TakeDamage();

                //Player est mort
                if (GetComponent<Player>().health <= 0)
                {
                    Destroy(currentSlice);
                    constantes.SaveGame();
                    SceneManager.LoadScene("Stage");
                }
                else
                {
                    ResetSlicer();
                }
            }
        }
    }

    public void CreateFight(GameObject other)
    {
        enemy = other;

        CreateSlicer();
        CreateTimer();

        gameObject.AddComponent<SwipeControls>();
        swipeControls = gameObject.GetComponent<SwipeControls>();
        swipeControls.slicer = currentSlice;

        gameObject.AddComponent<Swipe>();
        currentSwipe = gameObject.GetComponent<Swipe>();
        swipeControls.swipe = currentSwipe; 
    }

    private void CreateSlicer()
    {
        currentSlice = Instantiate(slicer) as GameObject;
        currentSlice.transform.SetParent(canvas.transform);
        currentSlice.GetComponent<RectTransform>().localPosition = new Vector3(0, 120, 0);
    }

    private void CreateTimer()
    {
        currentTimer = Instantiate(timer) as GameObject;
        currentTimer.transform.SetParent(canvas.transform);
        currentTimer.GetComponent<RectTransform>().localPosition = new Vector3(0, 370, 0);
    }

    private void Attack()
    {
        int degat = GetComponent<Player>().strenght;
        degat = Mathf.RoundToInt(Random.Range(degat - (degat * 0.1f), degat + (degat * 0.1f))); 

        currentPlayerDamage = Instantiate(playerDamage) as GameObject;
        currentPlayerDamage.GetComponent<PlayerDamage>().damage = degat;
        currentPlayerDamage.transform.SetParent(canvas.transform);
        currentPlayerDamage.GetComponent<RectTransform>().localPosition = new Vector3(0, 110, 0);
        currentPlayerDamage.GetComponent<TextMeshProUGUI>().fontSize = 36;
        enemy.GetComponent<Enemy>().health -= degat;
        enemy.GetComponent<Enemy>().healthBar.GetComponent<UnityEngine.UI.Image>().fillAmount = (float)enemy.GetComponent<Enemy>().health / enemy.GetComponent<Enemy>().maxHealth;
    }

    private void TakeDamage()
    {
        GameObject aie = Instantiate(playerHurt) as GameObject;
        aie.transform.SetParent(canvas.transform);
        aie.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        GetComponent<Player>().health -= enemy.GetComponent<Enemy>().strenght;
    }

    private void EnemyDie()
    {
        GetComponent<Player>().exp += enemy.GetComponent<Enemy>().exp;
        constantes.player_exp = GetComponent<Player>().exp;

        Destroy(enemy);
        GetComponent<Player>().isFighting = false;

        Destroy(currentSlice);
        Destroy(currentTimer);
        Destroy(GetComponent<SwipeControls>());
        Destroy(GetComponent<Swipe>());
    }

    private void LevelUp()
    {
        GetComponent<Player>().exp = GetComponent<Player>().exp - GetComponent<Player>().expMax;
        GetComponent<Player>().level++;
        GetComponent<Player>().expMax = Mathf.RoundToInt(GetComponent<Player>().expMax * (constantes.coeff * 1.1f)); 
        GetComponent<Player>().maxHealth = Mathf.RoundToInt(GetComponent<Player>().maxHealth * constantes.coeff);
        GetComponent<Player>().health = GetComponent<Player>().maxHealth;
        GetComponent<Player>().strenght = Mathf.RoundToInt(GetComponent<Player>().strenght * constantes.coeff);

        constantes.player_exp = GetComponent<Player>().exp;
        constantes.player_level = GetComponent<Player>().level;
        constantes.player_expMax = GetComponent<Player>().expMax;
        constantes.player_maxHealth = GetComponent<Player>().maxHealth;
        constantes.player_strenght = GetComponent<Player>().strenght;
    }

    private void ResetSlicer()
    {
        Destroy(currentSlice);
        if (swipeControls.swipeOK) { swipeControls.swipeOK = false; }
        if (swipeControls.swipeERR) { swipeControls.swipeERR = false; }

        CreateSlicer();
        swipeControls.slicer = currentSlice;
    }
}

