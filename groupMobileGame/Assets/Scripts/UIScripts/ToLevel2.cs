using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToLevel2 : MonoBehaviour {
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("EnemyBase").GetComponent<EnemyBaseHp>().Hp <= 0)
        {
            GetComponent<Canvas>().enabled = true;
        }

    }

    public void Level2()
    {
     SceneManager.LoadScene("Level2");
    }
}
