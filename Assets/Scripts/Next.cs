using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Next : MonoBehaviour
{
    public CameraMove obj;
    // Start is called before the first frame update
    void Start()
    {
        obj.enabled=false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            obj.enabled = true;
        }
    }
}
