using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerInputAction inputActions;

    private Vector2 axis => inputActions.Gameplay.Move.ReadValue<Vector2>();
    public float axisX => axis.x;
    public bool isMove => axisX != 0;
    public bool isJump => inputActions.Gameplay.Jump.WasPressedThisFrame();
    public bool stopJump => inputActions.Gameplay.Jump.WasReleasedThisFrame();

    private void Awake()
    {
        inputActions = new PlayerInputAction();
    }

    /// <summary>
    /// ÆôÓÃ¼üÅÌ
    /// </summary>
    public void EnableGameplayInput()
    {
        inputActions.Gameplay.Enable();
    }

    /// <summary>
    /// ½ûÓÃ¼üÅÌ
    /// </summary>
    public void DisableGameplayInput()
    {
        inputActions.Gameplay.Disable();
    }
}