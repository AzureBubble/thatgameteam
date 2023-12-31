using UnityEngine;
using UnityEngine.InputSystem;

public class CallVictoryUI : MonoBehaviour
{
    [SerializeField] private string targetSceneName;
    [SerializeField] private Vector3 targetPos;
    [SerializeField] private TwoParameterEventCenter<string, Vector3> StringVector3EventCenter;
    [SerializeField] private VoidEventCenter BeforeSceneLoadEventCenter;
    public AudioClip explodeSFX;

    private void OnEnable()
    {
        BeforeSceneLoadEventCenter.AddListener(OnBeforeSceneLoadEvent);
    }

    private void Update()
    {
        
    }

    private void OnDisable()
    {
        BeforeSceneLoadEventCenter.RemoveListener(OnBeforeSceneLoadEvent);
    }

    private void OnBeforeSceneLoadEvent()
    {
        SoundManager.audioSource.playOnAwake = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if(collision.TryGetComponent<PlayerController>(out PlayerController player))
        //{
        //  VictoryEventCenter.RaiseEvent();
        //}

        if (collision.tag == "prop")
        {
            GameObject.Find("Player").GetComponent<PlayerController>().currentSobarValue = 10000;
            SoundManager.audioSource.PlayOneShot(explodeSFX);
           
            StringVector3EventCenter.RaisedEvent(targetSceneName, targetPos);
        }
    }
}