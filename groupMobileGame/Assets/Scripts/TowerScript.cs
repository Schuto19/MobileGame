using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    public int Type;
    public float Health;
    float DamagedDelay;
    public GameObject DeathEffect;
    public float AttackDelay = 3;
    public GameObject Attack;
    public GameObject Attack2;
    public GameObject ChargeEffect;


    // Start is called before the first frame update
    void Start()
    {
        DamagedDelay = 1;
    }

    // Update is called once per frame
    void Update()
    {
        AttackDelay -= Time.deltaTime;
        GameObject[] Monsters = GameObject.FindGameObjectsWithTag("Monster");
        for(int i = 0; i < Monsters.Length; i++)
        {
            if((Monsters[i].transform.position - transform.position).magnitude < 5 && Type == 0)
            {
                if(AttackDelay <= 0)
                {
                    Instantiate(Attack, transform.position, Quaternion.identity);
                    AttackDelay = 3;
                }
            }
            if ((Monsters[i].transform.position - transform.position).magnitude < 10 && Type == 1)
            {
                if (AttackDelay <= 0)
                {
                    Instantiate(Attack2, transform.position, Quaternion.identity);
                    AttackDelay = 10;
                    Instantiate(ChargeEffect, transform.position, Quaternion.identity);
                }
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Monster")
        {
            DamagedDelay -= Time.deltaTime;
        }
        if (DamagedDelay <= 0 && Health > collision.gameObject.GetComponent<MonsterScript>().Damage)
        {
            Health -= collision.gameObject.GetComponent<MonsterScript>().Damage;
            GetComponent<ParticleSystem>().emission.SetBursts(new ParticleSystem.Burst[]{new ParticleSystem.Burst(.1f, collision.gameObject.GetComponent<MonsterScript>().Damage * 5)});
            GetComponent<ParticleSystem>().Play();
            DamagedDelay = 1;
        }
        if(DamagedDelay <= 0 && Health <= collision.gameObject.GetComponent<MonsterScript>().Damage)
        {
            Instantiate(DeathEffect, transform.position, Quaternion.identity);
            GameObject.Find("Currency").GetComponent<CurrencyScript>().Currency += 25;
            Destroy(gameObject);
        }
    }
}
