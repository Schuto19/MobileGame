using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float Lifetime;
    public int Damage;
    public float Velocity;
    public bool Piercing;
    public GameObject ShieldDamageEffect;

    // Start is called before the first frame update
    void Start()
    {
        float ClosestRange = 999;
        int TargetMonster = 0;
        GameObject[] Monsters = GameObject.FindGameObjectsWithTag("Monster");
        for(int i = 0; i < Monsters.Length; i++)
        {
            if((Monsters[i].transform.position - transform.position).magnitude < ClosestRange)
            {
                ClosestRange = (Monsters[i].transform.position - transform.position).magnitude;
                TargetMonster = i;
            }
        }
        GetComponent<Rigidbody2D>().velocity = (Monsters[TargetMonster].transform.position - transform.position).normalized * Velocity;
    }

    // Update is called once per frame
    void Update()
    {
        Lifetime -= Time.deltaTime;
        if(Lifetime <= 0)
        {
            Destroy(gameObject);
        }

        GameObject[] Monsters = GameObject.FindGameObjectsWithTag("Monster");
        for (int i = 0; i < Monsters.Length; i++)
        {
            float Range = (Monsters[i].transform.position - transform.position).magnitude;
            float DeathRange = 1.5f;
            if (Range < DeathRange)
            {
                if(Monsters[i].GetComponent<MonsterScript>().Type == 3 && Monsters[i].GetComponent<MonsterScript>().ShieldHealth > 0)
                {
                    Destroy(gameObject);
                    Monsters[i].GetComponent<MonsterScript>().ShieldHealth -= Damage;
                    Instantiate(ShieldDamageEffect, transform.position, Quaternion.identity);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster" && !Piercing)
        {
            Destroy(GetComponent<BoxCollider2D>());
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            Destroy(gameObject, 1);
        }
    }
}
