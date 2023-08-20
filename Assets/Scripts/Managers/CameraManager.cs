using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private VoidEventCenter CameraBlackEventCenter;
    [SerializeField] private VoidEventCenter AfterSceneLoadedEventCenter;
    [SerializeField] private VoidEventCenter PlayerDeadEventCenter;
    

    [SerializeField] private TwoParameterEventCenter<string, Vector3> StringVector3EventCenter;


    public CinemachineImpulseSource impulseSource;
    public float timer = 8.0f;
    public float currentTime = 0f;
    public bool isStop = false;
    public AudioClip shakeSFX;

    private void Awake()
    {
        //impulseSource = new CinemachineImpulseSource();
        currentTime = Time.time;
    }

    private void OnEnable()
    {
        StringVector3EventCenter.AddListener(OnStringVector3Event);
        AfterSceneLoadedEventCenter.AddListener(OnAfterSceneLoadedEvent);
        PlayerDeadEventCenter.AddListener(OnPlayerDeadEvent);

    }


    private void Update()
    {
        //print(Time.time);
        if(Time.time- currentTime>=timer&& !isStop)
        {
            SoundManager.audioSource.PlayOneShot(shakeSFX);
            PlayerShakeAnimation();
            currentTime = Time.time;
            CameraBlackEventCenter.RaiseEvent();
        }
    }

    private void OnDisable()
    {
        StringVector3EventCenter.RemoveListener(OnStringVector3Event);
        AfterSceneLoadedEventCenter.RemoveListener(OnAfterSceneLoadedEvent);
        PlayerDeadEventCenter.RemoveListener(OnPlayerDeadEvent);


    }

    private void OnPlayerDeadEvent()
    {
        isStop = true;
    }

    private void OnAfterSceneLoadedEvent()
    {
        isStop = false;
    }

    private void OnStringVector3Event(string arg1, Vector3 vector)
    {
        isStop = true;
    }

    public void PlayerShakeAnimation()
    {
        impulseSource.GenerateImpulse();
    }

}
