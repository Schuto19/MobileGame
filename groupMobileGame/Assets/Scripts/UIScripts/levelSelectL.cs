using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelSelectL : MonoBehaviour
{
    public void Level1()
    {
        SceneManager.LoadScene("level1L");
    }

    public void Level2()
    {
        SceneManager.LoadScene("level2L");
    }

    public void Level3()
    {
        SceneManager.LoadScene("level3L");
    }
}
