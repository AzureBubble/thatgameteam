using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ci : MonoBehaviour
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
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            collision.gameObject.GetComponent<PlayerController>().currentSobarValue -= 100;
        }
    }
}
