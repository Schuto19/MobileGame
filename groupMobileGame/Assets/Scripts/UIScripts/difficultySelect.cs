using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class difficultySelect : MonoBehaviour
{
    public void Normal()
    {
        SceneManager.LoadScene("levelSelectN");
    }

    public void Hard()
    {
        SceneManager.LoadScene("levelSelectH");
    }

    public void Lunatic()
    {
        SceneManager.LoadScene("levelSelectL");
    }
}
