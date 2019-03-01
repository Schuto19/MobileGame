using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveScript : MonoBehaviour
{
    float Lifetime = 3;
    public GameObject Explosion;
    public GameObject ExplosionEffect;
    // Start is called before the first frame update
    void Start()
    {
        float ClosestRange = 999;
        int TargetMonster = 0;
        GameObject[] Monsters = GameObject.FindGameObjectsWithTag("Monster");
        for (int i = 0; i < Monsters.Length; i++)
        {
            if ((Monsters[i].transform.position - transform.position).magnitude < ClosestRange)
            {
                ClosestRange = (Monsters[i].transform.position - transform.position).magnitude;
                TargetMonster = i;
            }
        }
        GetComponent<Rigidbody2D>().velocity = (Monsters[TargetMonster].transform.position - transform.position).normalized * 5;
    }

    // Update is called once per frame
    void Update()
    {
        Lifetime -= Time.deltaTime;
        if(Lifetime <= 0)
        {
            Instantiate(Explosion, transform.position, Quaternion.identity);
            Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
