using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private VoidEventCenter CameraBlackEventCenter;
    public CinemachineImpulseSource impulseSource;
    public float timer = 8.0f;
    public float currentTime = 0f;

    private void Awake()
    {
        //impulseSource = new CinemachineImpulseSource();
        currentTime = Time.time;
    }


    private void Update()
    {
        //print(Time.time);
        if(Time.time- currentTime>=timer)
        {
            PlayerShakeAnimation();
            currentTime = Time.time;
            CameraBlackEventCenter.RaiseEvent();
        }
    }

    public void PlayerShakeAnimation()
    {
        impulseSource.GenerateImpulse();
    }

}
