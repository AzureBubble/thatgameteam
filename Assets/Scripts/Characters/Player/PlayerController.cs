using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private VoidEventCenter BeforeSceneUnLoadEventCenter;
    [SerializeField] private VoidEventCenter AfterSceneLoadedEventCenter;
    [SerializeField] private VoidEventCenter PlayerDeadEventCenter;
    [SerializeField] private VoidEventCenter VictoryEventCenter;
    [SerializeField] private OneParamaterEventCenter<Vector3> MoveToPositionEventCenter;
    [SerializeField] private TwoParameterEventCenter<float, float> SobarChangeEventCenter;
    [SerializeField] private TwoParameterEventCenter<string, Vector3> StringVector3EventCenter;

    [Header("清醒度设置")]
    [SerializeField] private float maxSobarValue = 100f;

    [SerializeField] public float currentSobarValue;
    [SerializeField] private float decreaseSobarSpeed = 0.1f;
    public bool sobar;

    private PlayerInput input;
    private Rigidbody2D rb;
    private GroundCheck groundCheck;

    public Launch launch => GetComponentInChildren<Launch>();
    public AudioSource voicePlayer { get; private set; }
    public bool isGround => groundCheck.isGround;
    public bool doubleJump { get; set; } = false;
    public bool isFalling => rb.velocity.y < 0 && !isGround;
    public bool isSobar { get; set; } = false;
    public bool isInvincible { get; set; } = false;
    public bool canAttack { get; set; } = false;
    public bool isDead { get; set; } = false;
    public bool victory { get; set; } = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInput>();
        groundCheck = GetComponentInChildren<GroundCheck>();
        voicePlayer = GetComponent<AudioSource>();
        currentSobarValue = maxSobarValue;
    }

    private void OnEnable()
    {
        BeforeSceneUnLoadEventCenter.AddListener(OnBeforeSceneUnLoadEvent);
        AfterSceneLoadedEventCenter.AddListener(OnAfterSceneLoadedEvent);
        MoveToPositionEventCenter.AddListener(OnMoveToPositionEvent);
        VictoryEventCenter.AddListener(OnVictoryEvent);
        StringVector3EventCenter.AddListener(OnStringVector3Event);
    }

    private void Start()
    {
        input.EnableGameplayInput();
    }

    private void Update()
    {
        // TODO:测试用，注意修改
        if (sobar && currentSobarValue >= 0 && !isInvincible)
        {
            currentSobarValue = Mathf.MoveTowards(currentSobarValue, 0, decreaseSobarSpeed * Time.deltaTime);
            SobarChangeEventCenter.RaisedEvent(currentSobarValue, maxSobarValue);
        }
        if (currentSobarValue <= 0)
        {
            isDead = true;
            PlayerDeadEventCenter.RaiseEvent();
            input.DisableGameplayInput();
        }
    }

    private void OnDisable()
    {
        BeforeSceneUnLoadEventCenter.RemoveListener(OnBeforeSceneUnLoadEvent);
        AfterSceneLoadedEventCenter.RemoveListener(OnAfterSceneLoadedEvent);
        MoveToPositionEventCenter.RemoveListener(OnMoveToPositionEvent);
        VictoryEventCenter.RemoveListener(OnVictoryEvent);
        StringVector3EventCenter.AddListener(OnStringVector3Event);


        //input.DisableGameplayInput();
    }

    

    private void OnVictoryEvent()
    {
        victory = true;
        input.DisableGameplayInput();
        sobar = false;
    }

    private void OnStringVector3Event(string arg1, Vector3 vector)
    {
        victory = true;
        input.DisableGameplayInput();
        sobar = false;
    }

    private void OnBeforeSceneUnLoadEvent()
    {
        victory = false;
        //print("场景卸载之前");

        input.DisableGameplayInput();
    }

    private void OnAfterSceneLoadedEvent()
    {
        //print("场景加载完成");

        input.EnableGameplayInput();
        sobar = true;
    }

    private void OnMoveToPositionEvent(Vector3 targetPos)
    {
        transform.position = targetPos;
    }

    public void Move(float speed)
    {
        if (input.isMove)
        {
            transform.localScale = new Vector3(-Mathf.Sign(input.axisX), 1, 1);
        }
        SetVolictyX(speed * input.axisX);
    }

    public void SetVelocity(Vector2 velocity)
    {
        rb.velocity = velocity;
    }

    public void SetVolictyX(float velocityX)
    {
        rb.velocity = new Vector2(velocityX, rb.velocity.y);
    }

    public void SetVolictyY(float velocityY)
    {
        rb.velocity = new Vector2(rb.velocity.x, velocityY);
    }

    public void SetGravity(float value)
    {
        rb.gravityScale = 1;
    }
}