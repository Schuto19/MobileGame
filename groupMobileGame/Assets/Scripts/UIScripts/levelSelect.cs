using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelSelect : MonoBehaviour


{
    public void Level1()
    {
        SceneManager.LoadScene("level1");
    }

    public void Level2()
    {
        SceneManager.LoadScene("level2");
    }

    public void Level3()
    {
        SceneManager.LoadScene("level3");
    }
}
