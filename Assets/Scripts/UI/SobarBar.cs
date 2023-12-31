using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SobarBar : MonoBehaviour
{
    [SerializeField] private TwoParameterEventCenter<float, float> SobarChangeEventCenter;
    [SerializeField] private VoidEventCenter PlayerDeadEventCenter;
    [SerializeField] private VoidEventCenter VictoryEventCenter;
    [SerializeField] private VoidEventCenter RestartGameEventCenter;
    [SerializeField] private VoidEventCenter BeforeSceneUnLoadEvent;
    [SerializeField] private VoidEventCenter AfterSceneLoadedEventCenter;
    [SerializeField] private VoidEventCenter GoBackToMenuEventCenter;
    [SerializeField] private TwoParameterEventCenter<string, Vector3> StringVector3EventCenter;
    [SerializeField] private TwoParameterEventCenter<string, Vector3> SceneNamePosEventCenter;
    [SerializeField] private VoidEventCenter CameraBlackEventCenter;
    [SerializeField] private VoidEventCenter CallHideSobarUIEventCenter;


    public GameObject sobarUI;
    public Image sobarImage;
    public GameObject successPanel;
    public GameObject DefeatPanel;
    public GameObject blackPanel;
    public float blackDuration = 1.0f;
    public AudioClip victorySource;
    public AudioClip defeatSource;

    private void OnEnable()
    {
        SobarChangeEventCenter.AddListener(OnSobarChangeEvent);
        PlayerDeadEventCenter.AddListener(OnPlayerDeadEvent);
        VictoryEventCenter.AddListener(OnVictoryEvent);
        RestartGameEventCenter.AddListener(OnRestartGameEvent);
        BeforeSceneUnLoadEvent.AddListener(OnBeforeSceneUnLoadEvent);
        //GoBackToMenuEventCenter.AddListener(OnGoBackToMenuEvent);
        StringVector3EventCenter.AddListener(OnStringVector3Event);
        CameraBlackEventCenter.AddListener(OnCameraBlackEvent);
        CallHideSobarUIEventCenter.AddListener(OnCallHideSobarUIEvent);
    }

    private void OnDisable()
    {
        SobarChangeEventCenter.RemoveListener(OnSobarChangeEvent);
        PlayerDeadEventCenter.RemoveListener(OnPlayerDeadEvent);
        VictoryEventCenter.RemoveListener(OnVictoryEvent);
        RestartGameEventCenter.RemoveListener(OnRestartGameEvent);
        BeforeSceneUnLoadEvent.RemoveListener(OnBeforeSceneUnLoadEvent);
        //GoBackToMenuEventCenter.RemoveListener(OnGoBackToMenuEvent);
        StringVector3EventCenter.RemoveListener(OnStringVector3Event);
        CameraBlackEventCenter.RemoveListener(OnCameraBlackEvent);
        CallHideSobarUIEventCenter.RemoveListener(OnCallHideSobarUIEvent);

    }

    private void OnCallHideSobarUIEvent()
    {
        sobarUI.SetActive(false);
    }

    private void OnCameraBlackEvent()
    {
        StartCoroutine(SetBlackPanel());
    }

    private IEnumerator SetBlackPanel()
    {
        blackPanel.SetActive(true);
        yield return new WaitForSeconds(blackDuration);
        blackPanel.SetActive(false);
    }

    private void OnStringVector3Event(string sceneName, Vector3 targetPos)
    {
        SoundManager.audioSource.PlayOneShot(victorySource);
        successPanel.SetActive(true);
        DefeatPanel.SetActive(false);
        //Time.timeScale = 0f;
        SceneNamePosEventCenter.RaisedEvent(sceneName, targetPos);
    }

    //private void OnGoBackToMenuEvent()
    //{
        
    //}

    private void OnBeforeSceneUnLoadEvent()
    {
        SoundManager.audioSource.Stop();

        successPanel.SetActive(false);
        DefeatPanel.SetActive(false);
    }

    private void OnRestartGameEvent()
    {
        successPanel.SetActive(false);
        DefeatPanel.SetActive(false);
    }

    private void OnVictoryEvent()
    {
        successPanel.SetActive(true);
        DefeatPanel.SetActive(false);
    }

    private void OnPlayerDeadEvent()
    {
        SoundManager.audioSource.PlayOneShot(defeatSource);
        DefeatPanel.SetActive(true);
        successPanel.SetActive(false);
    }

    private void OnSobarChangeEvent(float currentSobarValue, float maxSobarValue)
    {
        float persentage = currentSobarValue / maxSobarValue;
        OnSobarChange(persentage);
    }

    public void OnSobarChange(float persentage)
    {
        sobarImage.fillAmount = persentage;
    }
}