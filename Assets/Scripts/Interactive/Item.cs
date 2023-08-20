using System.Collections;
using UnityEngine;

public class Item : MonoBehaviour
{
    private Rigidbody2D rb;
    public int state;
    public Vector2 pdir;
    GameObject player;
    [SerializeField] private float throwForce;
    [SerializeField] private float awakeTime = 0.8f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Init(Vector2 dir)
    {
        player = GameObject.Find("Player");
        state = 1;
        pdir = ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)player.transform.position).normalized;
        rb.AddForce(pdir * throwForce, ForceMode2D.Impulse);
        rb.gravityScale = 1;
        StartCoroutine(DestoryObj());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerController>(out PlayerController player))
        {
            if (state == 0&& player.canAttack!=true)
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