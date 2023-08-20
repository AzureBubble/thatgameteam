using System.Collections;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float jumpInputBufferTime = 0.5f;

    private PlayerInputAction inputActions;
    private Vector2 axis => inputActions.Gameplay.Move.ReadValue<Vector2>();
    public float axisX => axis.x;
    public bool isMove => axisX != 0;
    public bool isJump => inputActions.Gameplay.Jump.WasPressedThisFrame();
    public bool stopJump => inputActions.Gameplay.Jump.WasReleasedThisFrame();
    public bool isAttack => inputActions.Gameplay.Attack.WasPressedThisFrame();

    public bool hasJumpInputBuffer { get; set; }

    private void Awake()
    {
        inputActions = new PlayerInputAction();
    }

    private void OnEnable()
    {
        inputActions.Gameplay.Jump.canceled += delegate
        {
            hasJumpInputBuffer = false;
        };
    }

    public void SetJumpInputBufferTime()
    {
        StopCoroutine(JumpInputBufferTimeCoroutine());
        StartCoroutine(JumpInputBufferTimeCoroutine());
    }

    private IEnumerator JumpInputBufferTimeCoroutine()
    {
        hasJumpInputBuffer = true;

        yield return new WaitForSeconds(jumpInputBufferTime);

        hasJumpInputBuffer = false;
    }

    /// <summary>
    /// ∆Ù”√º¸≈Ã
    /// </summary>
    public void EnableGameplayInput()
    {
        inputActions.Gameplay.Enable();
    }

    /// <summary>
    /// Ω˚”√º¸≈Ã
    /// </summary>
    public void DisableGameplayInput()
    {
        inputActions.Gameplay.Disable();
    }
}