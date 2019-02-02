using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    public float Speed;
    public int Damage;
    GameObject Target;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        GameObject[] Towers = GameObject.FindGameObjectsWithTag("Tower");
        float ClosestRange = 1000;

        for (int i = 0; i < Towers.Length; i++)
        {
            float Range = (Towers[i].transform.position - transform.position).magnitude;
            if (Range < ClosestRange)
            {
                ClosestRange = Range;
                Target = Towers[i];
            }

        }

        if(Towers.Length > 0)
        {
            GetComponent<Rigidbody2D>().velocity = (Target.transform.position - transform.position).normalized * Speed;
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = (GameObject.Find("EndGoal").transform.position - transform.position).normalized * Speed;
        }
    }
}
