using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//check if p key is pressed
        if(Input.GetKeyDown(KeyCode.P))
        {
            //if pressed, stop stuff from moving
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                //and make pause menu visible.
                GetComponent<Canvas>().enabled = true;
            }else
            {
                //unpause
                Resume();
            }
        }
   
    }

    public void Resume()
    {
        Time.timeScale = 1;
        GetComponent<Canvas>().enabled = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene("Maze");
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
