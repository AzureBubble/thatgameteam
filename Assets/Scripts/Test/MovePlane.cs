using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlane : MonoBehaviour
{

    private bool moveDir;
    public float lerpSpeed;
    public Transform startPoint;
    public Transform endPoint;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        lerpSpeed = 1;
        sr = GetComponent<SpriteRenderer>();
        moveDir = true;
        sr.flipX = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveDir)//从起点到终点
        {
            transform.localPosition = Vector2.Lerp(transform.localPosition, endPoint.localPosition,lerpSpeed*Time.deltaTime);
            if (Vector2.Distance(transform.localPosition, endPoint.localPosition) <= 0.1f)
            {
                sr.flipX = false;
                moveDir = false;

            }
        }
        else
        {
            transform.localPosition = Vector2.Lerp(transform.localPosition, startPoint.localPosition, lerpSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.localPosition, startPoint.localPosition) <= 0.1f)
            {
                sr.flipX = true;
                moveDir = true;
            }
        }

    }
}
