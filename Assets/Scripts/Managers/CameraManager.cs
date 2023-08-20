using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraManager : MonoBehaviour
{
    public CinemachineImpulseSource impulseSource;

    private void Awake()
    {
        //impulseSource = new CinemachineImpulseSource();
    }

    private void Update()
    {
        if(Keyboard.current.qKey.isPressed)
        {
            PlayerShakeAnimation();
        }
    }

    public void PlayerShakeAnimation()
    {
        impulseSource.GenerateImpulse();
    }

}
