using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBaseHp : MonoBehaviour
{
    public float Hp = 100;
    float DamagedDelay = 1;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyUnit")
        {
            DamagedDelay -= Time.deltaTime;
        }
        if (DamagedDelay <= 0 && Hp > collision.gameObject.GetComponent<EnemyUnitScript>().Damage)
        {
            Hp -= collision.gameObject.GetComponent<EnemyUnitScript>().Damage;
            GetComponent<ParticleSystem>().emission.SetBursts(new ParticleSystem.Burst[] { new ParticleSystem.Burst(.1f, collision.gameObject.GetComponent<EnemyUnitScript>().Damage * 5) });
            GetComponent<ParticleSystem>().Play();
            DamagedDelay = 1;
        }
        if (DamagedDelay <= 0 && Hp <= collision.gameObject.GetComponent<EnemyUnitScript>().Damage)
        {
            GameObject.Find("LoseCanvas").GetComponent<Canvas>().enabled = true;
            GameObject.Find("MainCanvas").GetComponent<Canvas>().enabled = false;
            Time.timeScale = 0;
        }
    }
}
