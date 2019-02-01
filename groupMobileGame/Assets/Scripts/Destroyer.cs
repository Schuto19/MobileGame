using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public float Countdown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Countdown -= Time.deltaTime;
        if(Countdown <= 0)
        {
            Destroy(gameObject);
        }
    }
}
