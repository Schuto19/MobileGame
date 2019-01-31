using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningScript : MonoBehaviour
{
    public GameObject[] Monsters;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn0()
    {
        Instantiate(Monsters[0], transform.position, Quaternion.identity);
    }
    public void Spawn1()
    {
        Instantiate(Monsters[1], transform.position, Quaternion.identity);
    }
    public void Spawn2()
    {
        Instantiate(Monsters[2], transform.position, Quaternion.identity);
    }
    public void Spawn3()
    {
        Instantiate(Monsters[3], transform.position, Quaternion.identity);
    }
}
