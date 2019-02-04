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
        Instantiate(Monsters[0], SpawnPoint.transform.position, Quaternion.identity);
    }
    public void Spawn1()
    {
        Instantiate(Monsters[1], SpawnPoint.transform.position, Quaternion.identity);
    }
    public void Spawn2()
    {
        Instantiate(Monsters[2], SpawnPoint.transform.position, Quaternion.identity);
    }
    public void Spawn3()
    {
        Instantiate(Monsters[3], SpawnPoint.transform.position, Quaternion.identity);
    }
    public void Spawn4()
    {
        Instantiate(Monsters[4], SpawnPoint.transform.position, Quaternion.identity);
    }
}
