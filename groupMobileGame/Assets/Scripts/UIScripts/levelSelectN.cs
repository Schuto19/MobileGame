using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelSelectN : MonoBehaviour
{
    public void Level1()
    {
        SceneManager.LoadScene("level1N");
    }

    public void Level2()
    {
        SceneManager.LoadScene("level2N");
    }

    public void Level3()
    {
        SceneManager.LoadScene("level3N");
    }
}
