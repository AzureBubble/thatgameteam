using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    // Start is called before the first frame update
    //设置一个开关
    bool key;

    public GameObject player;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //如果触碰的是玩家
        if (collision.tag == "prop")
        {   //开关为true
            key = true;
        }
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (key)
        {
            Endlevel();
        }
    }

    private void Endlevel()
    {
        //打包用这个
        //Application.Quit();

        UnityEditor.EditorApplication.isPlaying = false; 
    }
}
