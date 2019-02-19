using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//check to see if the p key is pressed
        if(Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                //if it is pressed, stop stuff from moving and make the pause menu visible
                Time.timeScale = 0;
                GetComponent<Canvas>().enabled = true;
            }
            else if(Time.timeScale == 0)
            {
                Resume();
            }
        }
        
	}

    public void Resume()
    {
        Time.timeScale = 1;
        GetComponent<Canvas>().enabled = false;
    }
}
