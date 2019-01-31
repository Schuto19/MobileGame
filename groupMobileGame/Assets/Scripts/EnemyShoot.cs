using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    public GameObject prefab;
    public GameObject player;
    public float shootSpeed = 10;
    float timer = 0;
    public float shootTriggerDistance = 3.0f;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        Vector3 playerPosition = player.transform.position;
        //vector from enemy position to the players position
        Vector3 shootDirection = playerPosition - transform.position;
        if (shootDirection.magnitude < shootTriggerDistance && timer > 1.5f)
        {
            timer = 0;
            //Change from idle animation

            //shoot because the player is close to the enemy
            Vector3 shootDir = playerPosition - transform.position;
            shootDir.Normalize();
            GameObject bullet = (GameObject)Instantiate(prefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = shootDir  * shootSpeed;
            Destroy(bullet, 1.0f);

        }
    }
}
