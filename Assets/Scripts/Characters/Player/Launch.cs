using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    public void LaunchObj(float dir)
    {
        GameObject obj = Instantiate(prefab,transform.position,Quaternion.identity);
        obj.GetComponent<Item>().Init(new Vector2(dir,0));
    }
}
