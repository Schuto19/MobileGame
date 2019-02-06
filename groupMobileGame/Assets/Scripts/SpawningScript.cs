using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningScript : MonoBehaviour
{
    public GameObject[] Monsters;
    GameObject SpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPoint = GameObject.Find("MonsterSpawnPoint");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn0()
    {
        if(GameObject.Find("Currency").GetComponent<CurrencyScript>().Currency >= 5)
        {
            Instantiate(Monsters[0], SpawnPoint.transform.position, Quaternion.identity);
            GameObject.Find("Currency").GetComponent<CurrencyScript>().Currency -= 5;
        }
    }
    public void Spawn1()
    {
        if (GameObject.Find("Currency").GetComponent<CurrencyScript>().Currency >= 10)
        {
            Instantiate(Monsters[1], SpawnPoint.transform.position, Quaternion.identity);
            GameObject.Find("Currency").GetComponent<CurrencyScript>().Currency -= 10;
        }
    }
    public void Spawn2()
    {
        if (GameObject.Find("Currency").GetComponent<CurrencyScript>().Currency >= 10)
        {
            Instantiate(Monsters[2], SpawnPoint.transform.position, Quaternion.identity);
            GameObject.Find("Currency").GetComponent<CurrencyScript>().Currency -= 10;
        }
    }
    public void Spawn3()
    {
        if (GameObject.Find("Currency").GetComponent<CurrencyScript>().Currency >= 75)
        {
            Instantiate(Monsters[3], SpawnPoint.transform.position, Quaternion.identity);
            GameObject.Find("Currency").GetComponent<CurrencyScript>().Currency -= 75;
        }
    }
    public void Spawn4()
    {
        if (GameObject.Find("Currency").GetComponent<CurrencyScript>().Currency >= 999)
        {
            Instantiate(Monsters[4], SpawnPoint.transform.position, Quaternion.identity);
            GameObject.Find("Currency").GetComponent<CurrencyScript>().Currency -= 999;
        }
    }
}
