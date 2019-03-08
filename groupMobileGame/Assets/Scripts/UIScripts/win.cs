using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class win : MonoBehaviour {


    private void Update()
    {
        if(GameObject.Find("EnemyBase").GetComponent<EnemyBase>().Ending == true)
        {
            GetComponent<Canvas>().enabled = true;
        }
    }

}
