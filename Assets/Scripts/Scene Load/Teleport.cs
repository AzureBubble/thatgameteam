using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private string targetSceneName;
    [SerializeField] private Vector3 targetPos;
    [SerializeField] private TwoParameterEventCenter<string, Vector3> StringVector3EventCenter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerController>(out PlayerController player))
        {
            StringVector3EventCenter.RaisedEvent(targetSceneName, targetPos);
        }
    }
}