using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private float checkRadius = 0.1f;
    [SerializeField] private LayerMask groundLayer;
    private Collider2D[] colls = new Collider2D[1];
    float waittime;
    bool stand;

    public bool isGround => Physics2D.OverlapCircleNonAlloc(transform.position, checkRadius, colls, groundLayer) != 0||stand;
    public void Awake()
    {
        stand = false;
    }
    public void Update()
    {
        if (waittime == 0)
        {
            stand = false;
        }
        if (isGround != true)
        {
            waittime += Time.deltaTime;
            if (waittime >=3)
            {
                waittime = 0;
                stand=true;
            }
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, checkRadius);
    }
}