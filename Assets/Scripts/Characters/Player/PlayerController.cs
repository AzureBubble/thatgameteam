using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private VoidEventCenter BeforeSceneUnLoadEventCenter;
    [SerializeField] private VoidEventCenter AfterSceneLoadedEventCenter;
    [SerializeField] private OneParamaterEventCenter<Vector3> MoveToPositionEventCenter;
    [SerializeField] private TwoParameterEventCenter<float, float> SobarChangeEventCenter;

    [Header("清醒度设置")]
    [SerializeField] private float maxSobarValue = 100f;

    [SerializeField] private float currentSobarValue;
    [SerializeField] private float decreaseSobarSpeed = 0.1f;
    public bool sobar;

    private PlayerInput input;
    private Rigidbody2D rb;
    private GroundCheck groundCheck;

    public Launch launch => GetComponentInChildren<Launch>();
    public AudioSource voicePlayer { get; private set; }
    public bool isGround => groundCheck.isGround;
    public bool doubleJump { get; set; } = false;
    public bool isFalling => rb.velocity.y < 0 && isGround;
    public bool isSobar { get; set; } = false;
    public bool isInvincible { get; set; } = false;
    public bool canAttack { get; set; } = false;

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
    }

    private void OnDisable()
    {
        BeforeSceneUnLoadEventCenter.RemoveListener(OnBeforeSceneUnLoadEvent);
        AfterSceneLoadedEventCenter.RemoveListener(OnAfterSceneLoadedEvent);
        MoveToPositionEventCenter.RemoveListener(OnMoveToPositionEvent);

        //input.DisableGameplayInput();
    }

    private void OnBeforeSceneUnLoadEvent()
    {
        print("场景卸载之前");

        input.DisableGameplayInput();
    }

    private void OnAfterSceneLoadedEvent()
    {
        print("场景加载完成");

        input.EnableGameplayInput();
    }

    private void OnMoveToPositionEvent(Vector3 targetPos)
    {
        transform.position = targetPos;
    }

    public void Move(float speed)
    {
        if (input.isMove)
        {
            transform.localScale = new Vector3(-input.axisX, 1, 1);
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
        rb.gravityScale = value;
    }
}