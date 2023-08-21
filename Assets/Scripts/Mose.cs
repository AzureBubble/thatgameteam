using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mose : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerController>().canAttack)
        {
            Cursor.visible = false;
            transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else
        {
            Cursor.visible = true;
            transform.position = new Vector2(1000, 1000);
        }
    }
}
