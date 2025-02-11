using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public string scene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UnlockNewLevel();

            SoundManager.Instance.PlayLevelMusic(scene);
            SceneManager.LoadSceneAsync(scene);
        }
    }

    void UnlockNewLevel()
    {
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        int reachedIndex = PlayerPrefs.GetInt("ReachedIndex", 1);

        // If the player is progressing to a new level, update their progress
        if (currentLevelIndex >= reachedIndex)
        {
            PlayerPrefs.SetInt("ReachedIndex", currentLevelIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", currentLevelIndex + 1);  // Ensure only next level is unlocked
            PlayerPrefs.Save();

            Debug.Log("Level Completed: " + currentLevelIndex + ", Next unlocked level: " + (currentLevelIndex + 1));
        }
    }
}
