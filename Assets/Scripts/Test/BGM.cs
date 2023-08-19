using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    public AudioClip[] audios;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Audio());
    }
    // Update is called once per frame

    IEnumerator Audio()
    {
        for (int i = 0; i < 1000; i++)
        {
            int a = i % 2;
            this.GetComponent<AudioSource>().clip = audios[a];
            this.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(audios[a].length);
        }
    }




}
