using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Box : MonoBehaviour
{
    public string str;
    public TextMeshProUGUI text;
    public GameObject story;
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
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0.5f;
                text.text = str;
                story.SetActive(true);

            }

        }
    }
}
