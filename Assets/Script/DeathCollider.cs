using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            PlayerMovement.health--;
            int currentSceneIndex2 = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex2);
            if (PlayerMovement.health <= 0)
            {
                int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(currentSceneIndex);
                PlayerMovement.health = 3;
            }
        }

    }
}
