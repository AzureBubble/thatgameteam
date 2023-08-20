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


    private void Update()
    {
       


        cm.transform.localPosition = Vector3.Lerp(cm.transform.localPosition, point[count].localPosition, speed * Time.deltaTime);

        if (count<point.Length)
        {
            if (Input.GetMouseButtonDown(0) && (Vector2.Distance(cm.transform.position, point[count].transform.localPosition) < 0.5f))
            {
                count++;
            }
        }

    }


    


}
