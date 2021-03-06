﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    public int Type;
    public float Health;
    public float Speed;
    public float Damage;
    bool Attacking = false;
    public bool Fighting = false;
    public float FightDelay = 1;
    int Progress = 0;
    public GameObject DeathEffect;
    public float ShieldHealth = 14;
    float ShieldRepairTime = 10;
    public GameObject ShieldEffect;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Attacking = false;

        if(Type == 2 || Type == 4)
        {
            GameObject[] Towers = GameObject.FindGameObjectsWithTag("Tower");
            float ClosestRange = 2.5f;

            for (int i = 0; i < Towers.Length; i++)
            {
                float Range = (Towers[i].transform.position - transform.position).magnitude;
                if (Range < ClosestRange)
                {
                    Attacking = true;
                    ClosestRange = Range;
                    GetComponent<Rigidbody2D>().velocity = (Towers[i].transform.position - transform.position).normalized * Speed;
                }
            }
        }


        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("EnemyUnit");
        float ClosestRange2;
        if(Type == 2)
        {
            ClosestRange2 = 1.25f;
        }
        else
        {
            ClosestRange2 = 1.5f;
        }

        Fighting = false;

        for (int i = 0; i < Enemies.Length; i++)
        {
            float Range = (Enemies[i].transform.position - transform.position).magnitude;
            if (Range < ClosestRange2)
            {
                Fighting = true;
                ClosestRange2 = Range;
                GetComponent<Rigidbody2D>().velocity = ((Enemies[i].transform.position - transform.position).normalized * Speed) / 10;
                if(Type != 3)
                {
                    FightDelay -= Time.deltaTime;
                }
                if (Enemies[i].GetComponent<EnemyUnitScript>().FightDelay <= 0)
                {
                    Health -= Enemies[i].GetComponent<EnemyUnitScript>().Damage;
                    if (Health > 0)
                    {
                        GetComponent<ParticleSystem>().emission.SetBursts(new ParticleSystem.Burst[] { new ParticleSystem.Burst(.1f, Enemies[i].GetComponent<EnemyUnitScript>().Damage * 5) });
                        GetComponent<ParticleSystem>().Play();
                    }
                    else
                    {
                        Instantiate(DeathEffect, transform.position, Quaternion.identity);
                        Destroy(gameObject);
                    }
                    Enemies[i].GetComponent<EnemyUnitScript>().FightDelay = 1;
                }
            }
        }

        GameObject[] Path = GameObject.FindGameObjectsWithTag("Path");

        if(!Attacking && !Fighting)
        {
            for (int i = 0; i < Path.Length; i++)
            {
                if(Path[i].GetComponent<PathScript>().PathPiece == Progress)
                {
                    GetComponent<Rigidbody2D>().velocity = (Path[i].transform.position - transform.position).normalized * Speed;

                    if ((Path[i].transform.position - transform.position).magnitude < .5f)
                    {
                        Progress += 1;
                    }
                }
            }

            if(Progress == Path.Length)
            {
                GetComponent<Rigidbody2D>().velocity = (GameObject.FindGameObjectWithTag("EnemyBase").transform.position - transform.position).normalized * Speed;
            }
        }

        if(Type == 3 && ShieldHealth <= 0)
        {
            ShieldRepairTime -= Time.deltaTime;
            ShieldEffect.GetComponent<ParticleSystem>().Stop();
        }
        if(ShieldRepairTime <= 0)
        {
            ShieldHealth = 20;
            ShieldRepairTime = 10;
            ShieldEffect.GetComponent<ParticleSystem>().Play();
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "TowerProjectile")
        {
            Health -= collision.gameObject.GetComponent<ProjectileScript>().Damage;
            if(Health > 0)
            {
                GetComponent<ParticleSystem>().emission.SetBursts(new ParticleSystem.Burst[] { new ParticleSystem.Burst(.1f, collision.gameObject.GetComponent<ProjectileScript>().Damage * 5) });
                GetComponent<ParticleSystem>().Play();
            }
            else
            {
                Instantiate(DeathEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
