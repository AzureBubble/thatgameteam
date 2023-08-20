using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallVictoryUI : MonoBehaviour
{
    [SerializeField] private string targetSceneName;
    [SerializeField] private Vector3 targetPos;
    [SerializeField] private TwoParameterEventCenter<string, Vector3> StringVector3EventCenter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if(collision.TryGetComponent<PlayerController>(out PlayerController player))
        //{
        //  VictoryEventCenter.RaiseEvent();
        //}
        if (collision.tag == "prop")
        {
            StringVector3EventCenter.RaisedEvent(targetSceneName, targetPos);
        }
    }
}
