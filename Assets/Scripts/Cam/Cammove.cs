using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cammove : MonoBehaviour
{
    public GameObject player;
    public int movestate;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        move();
        field();
    }
    void field()//·¶Î§
    {
        if (transform.position.x < -4.5f)
        {
            transform.position = new Vector3(-4.5f, transform.position.y, -10);
        }
        if (transform.position.x > 4.5f)
        {
            transform.position = new Vector3(4.5f, transform.position.y, -10);
        }
        if (transform.position.y < -9f)
        {
            transform.position = new Vector3(transform.position.x, -9f, -10);
        }
        if (transform.position.y > 9f)
        {
            transform.position = new Vector3(transform.position.x, 9f, -10);
        }

    }
    void move()
    {
        if (((Vector2)player.transform.position - (Vector2)transform.position).magnitude > 3f)
        {
            movestate = 1;
        }

        if (movestate == 1)
        {
            transform.Translate(((Vector2)player.transform.position - (Vector2)transform.position).normalized * Time.deltaTime * 5);
            if (((Vector2)player.transform.position - (Vector2)transform.position).magnitude < 1)
            {
                movestate = 0;
            }
        }


    }
}
