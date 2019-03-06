using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    public int Type;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().SetInteger("Type", Type);
    }

    // Update is called once per frame
    void Update()
    {
        if(Type != 7)
        {
            if (GetComponent<Rigidbody2D>().velocity.x < 0 && Type != 1)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else if (GetComponent<Rigidbody2D>().velocity.x > 0 && Type != 1)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }

            if (GetComponent<Rigidbody2D>().velocity.x < 0 && Type == 1)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else if (GetComponent<Rigidbody2D>().velocity.x > 0 && Type == 1)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }
    }
}
