using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    // Start is called before the first frame update
    //����һ������
    bool key;

    public GameObject player;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //��������������
        if (collision.tag == "prop")
        {   //����Ϊtrue
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
        //��������
        //Application.Quit();

        UnityEditor.EditorApplication.isPlaying = false; 
    }
}
