using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lose : MonoBehaviour
{
   
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("PlayerBase").GetComponent<playerBaseHp>().Hp <= 0)
        {
            GetComponent<Canvas>().enabled = true;
        }
    }
}
