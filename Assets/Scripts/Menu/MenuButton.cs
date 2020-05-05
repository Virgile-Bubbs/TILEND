using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    public void NewGame()
    {
        PlayerPrefs.SetInt("new_game", 1);
        SceneManager.LoadScene("Stage");
    }

    public void LoadGame()
    {
        PlayerPrefs.SetInt("new_game", 0);
        SceneManager.LoadScene("Stage");
    }
}
