using System;
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


    public Image sobarImage;
    public GameObject successPanel;
    public GameObject DefeatPanel;

    private void OnEnable()
    {
        SobarChangeEventCenter.AddListener(OnSobarChangeEvent);
        PlayerDeadEventCenter.AddListener(OnPlayerDeadEvent);
        VictoryEventCenter.AddListener(OnVictoryEvent);
        RestartGameEventCenter.AddListener(OnRestartGameEvent);
        BeforeSceneUnLoadEvent.AddListener(OnBeforeSceneUnLoadEvent);
        GoBackToMenuEventCenter.AddListener(OnGoBackToMenuEvent);
    }

    private void OnDisable()
    {
        SobarChangeEventCenter.RemoveListener(OnSobarChangeEvent);
        PlayerDeadEventCenter.RemoveListener(OnPlayerDeadEvent);
        VictoryEventCenter.RemoveListener(OnVictoryEvent);
        RestartGameEventCenter.RemoveListener(OnRestartGameEvent);
        BeforeSceneUnLoadEvent.RemoveListener(OnBeforeSceneUnLoadEvent);
        GoBackToMenuEventCenter.RemoveListener(OnGoBackToMenuEvent);

    }

    private void OnGoBackToMenuEvent()
    {
        throw new NotImplementedException();
    }

    private void OnBeforeSceneUnLoadEvent()
    {
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