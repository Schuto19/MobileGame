﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public float Health = 100;
    float DamagedDelay = 1;
    float SpawnDelay1;
    float SpawnDelay2;
    float SpawnDelay3;
    public GameObject DeathEffect;
    public GameObject EnemyUnit1;
    public GameObject EnemyUnit2;
    public GameObject EnemyUnit3;
    public bool Ending = false;
    float EndTimer = 2;

    // Start is called before the first frame update
    void Start()
    {
            SpawnDelay1 = Random.Range(18f, 24f);
            SpawnDelay2 = Random.Range(36f, 48f);
            SpawnDelay3 = Random.Range(36f, 48f);
    }

    // Update is called once per frame
    void Update()
    {
        SpawnDelay1 -= Time.deltaTime;
        SpawnDelay2 -= Time.deltaTime;
        SpawnDelay3 -= Time.deltaTime;
        if (SpawnDelay1 <= 0 && !Ending)
        {
            Instantiate(EnemyUnit1, transform.position + new Vector3(0, -1.5f, 0), Quaternion.identity);
            SpawnDelay1 = Random.Range(9f, 12f);
        }
        if (SpawnDelay2 <= 0 && !Ending)
        {
            Instantiate(EnemyUnit2, transform.position + new Vector3(0, -1.5f, 0), Quaternion.identity);
            SpawnDelay2 = Random.Range(18f, 24f);
        }
        if (SpawnDelay3 <= 0 && !Ending)
        {
            Instantiate(EnemyUnit3, transform.position + new Vector3(0, -1.5f, 0), Quaternion.identity);
            SpawnDelay3 = Random.Range(18f, 24f);
        }

        if (Ending)
        {
            EndTimer -= Time.deltaTime;
        }
        if(EndTimer <= 0)
        {
            Health = 0;
            Time.timeScale = 0;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Monster" && collision.gameObject.GetComponent<MonsterScript>().Type != 3)
        {
            DamagedDelay -= Time.deltaTime;
        }
        if (DamagedDelay <= 0 && Health > collision.gameObject.GetComponent<MonsterScript>().Damage)
        {
            Health -= collision.gameObject.GetComponent<MonsterScript>().Damage;
            GetComponent<ParticleSystem>().emission.SetBursts(new ParticleSystem.Burst[] { new ParticleSystem.Burst(.1f, collision.gameObject.GetComponent<MonsterScript>().Damage * 5) });
            GetComponent<ParticleSystem>().Play();
            DamagedDelay = 1;
        }
        if (DamagedDelay <= 0 && Health <= collision.gameObject.GetComponent<MonsterScript>().Damage && EndTimer == 2)
        {
            Ending = true;
            GameObject.Find("LevelEndEffect").GetComponent<ParticleSystem>().Play();
            GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("MainCanvas").GetComponent<Canvas>().enabled = false;
        }
    }
}
