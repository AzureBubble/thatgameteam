using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private string targetSceneName;
    [SerializeField] private Vector3 targetPos;
    [SerializeField] private TwoParameterEventCenter<string, Vector3> SceneNamePosEventCenter;

    [SerializeField] private VoidEventCenter VictoryEventCenter;

    //[SerializeField] private VoidEventCenter MoveToTest002EventCenter;
    [SerializeField] private TwoParameterEventCenter<string, Vector3> MoveToNextSceneEventCenter;

    //[SerializeField] private GameObject successPanel;
    private void OnEnable()
    {
        SceneNamePosEventCenter.AddListener(OnStringVector3Event);
    }

    private void OnDisable()
    {
        SceneNamePosEventCenter.RemoveListener(OnStringVector3Event);
    }

    public void OnStringVector3Event(string targetSceneName, Vector3 targetPos)
    {
        this.targetSceneName = targetSceneName;
        this.targetPos = targetPos;
        print(targetSceneName + targetPos);
    }

    public void OnClick()
    {
        //if(collision.TryGetComponent<PlayerController>(out PlayerController player))
        //{
        //  VictoryEventCenter.RaiseEvent();
        //}

        //VictoryEventCenter.RaiseEvent();

        MoveToNextSceneEventCenter.RaisedEvent(targetSceneName, targetPos);
    }
}