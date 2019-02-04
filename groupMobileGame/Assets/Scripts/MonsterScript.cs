using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    public float Speed;
    public int Damage;
    bool Attacking = false;
    int Progress = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Attacking = false;

        GameObject[] Towers = GameObject.FindGameObjectsWithTag("Tower");
        float ClosestRange = 10f;

        for (int i = 0; i < Towers.Length; i++)
        {
            float Range = (Towers[i].transform.position - transform.position).magnitude;
            if (Range < ClosestRange)
            {
                Attacking = true;
                ClosestRange = Range;
                GetComponent<Rigidbody2D>().velocity = (Towers[i].transform.position - transform.position).normalized * Speed;
            }
            //if(Range > ClosestRange)
            //{
            //    Attacking = false;
            //}
        }

        GameObject[] Path = GameObject.FindGameObjectsWithTag("Path");

        if(!Attacking)
        {
            for (int i = 0; i < Path.Length; i++)
            {
                if(Path[i].GetComponent<PathScript>().PathPiece == Progress)
                {
                    GetComponent<Rigidbody2D>().velocity = (Path[i].transform.position - transform.position).normalized * Speed;

                    if ((Path[i].transform.position - transform.position).magnitude < 3.9f)
                    {
                        Progress += 1;
                    }
                }
            }
        }
    }
}
