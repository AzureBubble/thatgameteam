using System.Collections;
using UnityEngine;

public class Item : MonoBehaviour
{
    private Rigidbody2D rb;
    public int state;
    [SerializeField] private float throwForce;
    [SerializeField] private float awakeTime = 1.0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Init(Vector2 dir)
    {
        state = 1;
        rb.gravityScale = 1;
        Vector2 pdir = ((Vector2)Input.mousePosition - (Vector2)transform.position).normalized;
        rb.AddForce(pdir * throwForce, ForceMode2D.Impulse);
        StartCoroutine(DestoryObj());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerController>(out PlayerController player))
        {
            if (state == 0)
            {
                player.canAttack = true;
                this.gameObject.SetActive(false);
            }        
        }
    }

    IEnumerator DestoryObj()
    {
        yield return new WaitForSeconds(awakeTime);
        Destroy(this.gameObject);
    }
}