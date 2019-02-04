using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBottons : MonoBehaviour {

    int lives = 3;
    public void NewGame()
    {
        PlayerPrefs.SetInt("Lives", lives);
        SceneManager.LoadScene("level1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Controls()
    {
        SceneManager.LoadScene("Options");
    }
}
