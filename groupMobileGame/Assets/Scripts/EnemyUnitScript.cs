using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnitScript : MonoBehaviour
{
    public float Health;
    public float Speed;
    public float Damage;
    bool Attacking = false;
    public bool Fighting = false;
    public float FightDelay = 1;
    int Progress;
    public GameObject DeathEffect;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] Path = GameObject.FindGameObjectsWithTag("Path");
        Progress = Path.Length - 1;
    }

    // Update is called once per frame
    void Update()
    {
        //Attacking = false;

        //GameObject[] Towers = GameObject.FindGameObjectsWithTag("Tower");
        //float ClosestRange = 2f;

        //for (int i = 0; i < Towers.Length; i++)
        //{
        //    float Range = (Towers[i].transform.position - transform.position).magnitude;
        //    if (Range < ClosestRange)
        //    {
        //        Attacking = true;
        //        ClosestRange = Range;
        //        GetComponent<Rigidbody2D>().velocity = (Towers[i].transform.position - transform.position).normalized * Speed;
        //    }
        //}

        GameObject[] Monsters = GameObject.FindGameObjectsWithTag("Monster");
        float ClosestRange2 = 1.5f;

        Fighting = false;

        for (int i = 0; i < Monsters.Length; i++)
        {
            float Range = (Monsters[i].transform.position - transform.position).magnitude;
            if (Range < ClosestRange2)
            {
                Fighting = true;
                ClosestRange2 = Range;
                GetComponent<Rigidbody2D>().velocity = ((Monsters[i].transform.position - transform.position).normalized * Speed) / 10;
                FightDelay -= Time.deltaTime;
                if(Monsters[i].GetComponent<MonsterScript>().FightDelay <= 0)
                {
                    Health -= Monsters[i].GetComponent<MonsterScript>().Damage;
                    if (Health > 0)
                    {
                        GetComponent<ParticleSystem>().emission.SetBursts(new ParticleSystem.Burst[] { new ParticleSystem.Burst(.1f, Monsters[i].GetComponent<MonsterScript>().Damage * 5) });
                        GetComponent<ParticleSystem>().Play();
                    }
                    else
                    {
                        Instantiate(DeathEffect, transform.position, Quaternion.identity);
                        GameObject.Find("Currency").GetComponent<CurrencyScript>().Currency += 5;
                        Destroy(gameObject);
                    }
                    Monsters[i].GetComponent<MonsterScript>().FightDelay = 1;
                }
            }
        }

        GameObject[] Path = GameObject.FindGameObjectsWithTag("Path");

        if (!Attacking && !Fighting)
        {
            for (int i = 0; i < Path.Length; i++)
            {
                if (Path[i].GetComponent<PathScript>().PathPiece == Progress)
                {
                    GetComponent<Rigidbody2D>().velocity = (Path[i].transform.position - transform.position).normalized * Speed;

                    if ((Path[i].transform.position - transform.position).magnitude < .5f)
                    {
                        Progress -= 1;
                    }
                }
            }
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "TowerProjectile")
    //    {
    //        Health -= collision.gameObject.GetComponent<ProjectileScript>().Damage;
    //        if (Health > 0)
    //        {
    //            GetComponent<ParticleSystem>().emission.SetBursts(new ParticleSystem.Burst[] { new ParticleSystem.Burst(.1f, collision.gameObject.GetComponent<ProjectileScript>().Damage * 5) });
    //            GetComponent<ParticleSystem>().Play();
    //        }
    //        else
    //        {
    //            Instantiate(DeathEffect, transform.position, Quaternion.identity);
    //            Destroy(gameObject);
    //        }
    //    }
    //}
}
