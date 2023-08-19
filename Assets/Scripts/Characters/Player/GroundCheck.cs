using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private float checkRadius = 0.1f;
    [SerializeField] private LayerMask groundLayer;
    private Collider2D[] colls = new Collider2D[1];

    public bool isGround => Physics2D.OverlapCircleNonAlloc(transform.position, checkRadius, colls, groundLayer) != 0;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, checkRadius);
    }
}