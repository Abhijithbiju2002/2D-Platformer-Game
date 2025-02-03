using UnityEngine;

public class DeathCollider : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            PlayerMovement.health--;
            if (PlayerMovement.health <= 0)
            {
                PlayerMovement playerMovement = collision.gameObject.GetComponent<PlayerMovement>();
                playerMovement.KillPlayer();
            }
        }
    }
}
