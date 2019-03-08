using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBottons : MonoBehaviour {

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Begin()
    {
        SceneManager.LoadScene("difficultySelect");
    }

    public void ReturnToMain()
    {
        SceneManager.LoadScene("mainMenu");
    }
}
