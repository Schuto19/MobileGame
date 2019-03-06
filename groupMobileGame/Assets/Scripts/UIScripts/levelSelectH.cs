using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelSelectH : MonoBehaviour
{
    public void Level1()
    {
        SceneManager.LoadScene("level1H");
    }

    public void Level2()
    {
        SceneManager.LoadScene("level2H");
    }

    public void Level3()
    {
        SceneManager.LoadScene("level3H");
    }
}
