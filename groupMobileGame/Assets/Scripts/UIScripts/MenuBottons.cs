using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBottons : MonoBehaviour {

    public void NewGame()
    {
        
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

    public void Continue()
    {
        SceneManager.LoadScene("difficultySelect");
    }
}
