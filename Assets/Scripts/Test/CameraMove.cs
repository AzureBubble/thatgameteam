using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    //public Camera cm;

    //public Transform[] point;

    //private int count = 1;

    //public int speed = 1;


    //private void Update()
    //{
    //    if (count < point.Length)
    //    {
    //        if (Input.GetMouseButtonDown(0))
    //        {
    //            Click();
    //        }

    //    }
    //}


    //public void Click()
    //{
    //    cm.transform.localPosition = point[count].transform.localPosition;
    //    count++;
    //}


    public Camera cm;

    public Transform[] point;

    private int count = 0;

    public float speed = 1;

    public int scalespeed = 5;

    public float m_FieldOfView_1;

    public float m_FieldOfView_2;

    //public AudioClip[] audioClips;

    private void Start()
    {
        m_FieldOfView_1 = 70;
        m_FieldOfView_2 = 43;

    }


    private void Update()
    {
        
        cm.transform.localPosition = Vector3.Lerp(cm.transform.localPosition, point[count].localPosition, speed * Time.deltaTime);

        if (count<point.Length-1)
        {
            if (Input.GetMouseButtonDown(0) && (Vector2.Distance(cm.transform.position, point[count].transform.localPosition) < 0.5f))
            {
                count++;
            }

            if (count == 1)
            {
                //this.GetComponent<AudioSource>().clip = audioClips[count];
            }
            if (count == 2)
            {

            }
            if (count == 3)
            {

            }

            if (count == 4)
            {

                if (Camera.main.fieldOfView < m_FieldOfView_1)
                {
                    Camera.main.fieldOfView += (Time.deltaTime * scalespeed);
                }
            }

            if (count == 5)
            {
                if (Camera.main.fieldOfView > m_FieldOfView_2)
                {
                    Camera.main.fieldOfView -= (Time.deltaTime * scalespeed);
                }
            }

            if (count == 6)
            {

            }
            if (count == 7)
            {

            }
        }

       

    }


    


}
