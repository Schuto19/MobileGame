using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {


    public void Pause()
    {
        if (Time.timeScale == 1)
        {
         Time.timeScale = 0;
         GetComponent<Canvas>().enabled = true;
        }
        else if (Time.timeScale == 0)
        {
            Resume();
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
        GetComponent<Canvas>().enabled = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
