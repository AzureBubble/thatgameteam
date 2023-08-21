using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story : MonoBehaviour
{
    public float waittime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        waittime += Time.deltaTime;
        if (waittime >= 2)
        {
            Time.timeScale = 1;
            this.gameObject.transform.parent.gameObject.SetActive(false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Time.timeScale = 1;
            this.gameObject.transform.parent.gameObject.SetActive(false);          
        }
    }
}
