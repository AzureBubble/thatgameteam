using System;
using System.Collections;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public string sceneName;
    public Vector3 targetPos;
    [SerializeField] private TwoParameterEventCenter<string, Vector3> MoveToFirstSceneEventCenter;
    [SerializeField] private VoidEventCenter CallHideSobarUIEventCenter;
    //public bool isTransition;

    public Camera cm;

    public Transform[] point;

    private int count = 0;

    public float speed = 1;

    public int scalespeed = 5;

    public float m_FieldOfView_1;

    public float m_FieldOfView_2;

    public AudioClip[] audioClips;

    public float timer = 3.0f;
    public float currentTime;

   

    private void Start()
    {
        m_FieldOfView_1 = 70;
        m_FieldOfView_2 = 43;
        currentTime = Time.time;
    }

    private void Update()
    {
        CallHideSobarUIEventCenter.RaiseEvent();

        //this.GetComponent<AudioSource>().clip = audioClips[count];
        cm.transform.localPosition = Vector3.Lerp(cm.transform.localPosition, point[count].localPosition, speed * Time.deltaTime);

        if (count < point.Length - 1)
        {
            if ((Input.GetMouseButtonDown(0) && (Vector2.Distance(cm.transform.position, point[count].transform.localPosition) < 0.5f))||Time.time-currentTime >=timer)
            {
                count++;
                this.GetComponent<AudioSource>().clip = audioClips[0];
                this.GetComponent<AudioSource>().Play();
                currentTime = Time.time;    
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
                    Camera.main.fieldOfView += (Time.deltaTime * scalespeed * 1.5f);
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

        if (count == 6 && Input.GetMouseButtonDown(0) )
        {
            StartCoroutine(Transition(sceneName, targetPos));
        }
    }

 

    private void OnMoveToFirstSceneEvent(string sceneName, Vector3 targetPos)
    {
        MoveToFirstSceneEventCenter.RaisedEvent(sceneName, targetPos);
    }

    IEnumerator Transition(string sceneName, Vector3 targetPos)
    {
        yield return new WaitForSeconds(2f);
        OnMoveToFirstSceneEvent(sceneName, targetPos);
    }

}