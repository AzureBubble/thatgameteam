using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{ 

    public Camera cm;

    public Transform[] point;

    private int count = 0;

    public float speed = 1;

    public int scalespeed = 5;

    public float m_FieldOfView_1;

    public float m_FieldOfView_2;

    public AudioClip[] audioClips;

    private void Start()
    {
        m_FieldOfView_1 = 70;
        m_FieldOfView_2 = 43;

    }


    private void Update()
    {
        //this.GetComponent<AudioSource>().clip = audioClips[count];
        cm.transform.localPosition = Vector3.Lerp(cm.transform.localPosition, point[count].localPosition, speed * Time.deltaTime);

        if (count<point.Length-2)
        {
            if (Input.GetMouseButtonDown(0) && (Vector2.Distance(cm.transform.position, point[count].transform.localPosition) < 0.5f))
            {
                count++;
                this.GetComponent<AudioSource>().clip = audioClips[0];
                this.GetComponent<AudioSource>().Play();
            }
            //if (count ==1)
            //{
            //    this.GetComponent<AudioSource>().clip = audioClips[2];
            //    this.GetComponent<AudioSource>().Play();
            //}

            if (count == 4)
            {

                if (Camera.main.fieldOfView < m_FieldOfView_1)
                {
                    Camera.main.fieldOfView += (Time.deltaTime * scalespeed*1.5f);
                }
                //this.GetComponent<AudioSource>().clip = audioClips[1];
                //this.GetComponent<AudioSource>().Play();
            }

            if (count == 5)
            {
                if (Camera.main.fieldOfView > m_FieldOfView_2)
                {
                    Camera.main.fieldOfView -= (Time.deltaTime * scalespeed);
                }
            }

            
        }

       

    }


    


}
