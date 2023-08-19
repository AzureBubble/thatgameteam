using UnityEngine;

public class Bubble : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // TODO:ÆðÅÝ¸ÄÎÞµÐ
        if (collision.TryGetComponent<PlayerController>(out PlayerController player))
        {
            player.isInvincible = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerController>(out PlayerController player))
        {
            player.isInvincible = false;
        }
    }
}