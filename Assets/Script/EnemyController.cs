using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            PlayerMovement playerMovement = collision.gameObject.GetComponent<PlayerMovement>();
            playerMovement.KillPlayer();

        }
    }
}
