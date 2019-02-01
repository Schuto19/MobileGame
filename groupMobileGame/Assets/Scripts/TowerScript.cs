using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    public int Health;
    float DamagedDelay;
    public GameObject DeathEffect;

    // Start is called before the first frame update
    void Start()
    {
        DamagedDelay = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Monster")
        {
            DamagedDelay -= Time.deltaTime;
        }
        if (DamagedDelay <= 0 && Health > 1)
        {
            Health -= collision.gameObject.GetComponent<MonsterScript>().Damage;
            for(int i = 0; i < collision.gameObject.GetComponent<MonsterScript>().Damage; i++)
            {
                GetComponent<ParticleSystem>().Play();
            }
            DamagedDelay = 1;
        }
        if(DamagedDelay <= 0 && Health <= 1)
        {
            Instantiate(DeathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
