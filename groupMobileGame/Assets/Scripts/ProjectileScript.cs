using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float Lifetime;
    public int Damage;

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
        GetComponent<Rigidbody2D>().velocity = (Monsters[TargetMonster].transform.position - transform.position).normalized * 10;
    }

    // Update is called once per frame
    void Update()
    {
        Lifetime -= Time.deltaTime;
        if(Lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            Destroy(gameObject);
        }
    }
}
