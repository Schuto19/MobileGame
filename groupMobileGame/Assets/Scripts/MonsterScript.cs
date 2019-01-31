﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    public float Speed;
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


        GetComponent<Rigidbody2D>().velocity = (Target.transform.position - transform.position).normalized * Speed;
    }
}