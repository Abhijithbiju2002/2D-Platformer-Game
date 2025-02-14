using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverControler : MonoBehaviour
{
    public Button buttonRestart;


    private void Awake()
    {
        buttonRestart.onClick.AddListener(ReloadLevel);
    }
    public void PlayerDied()
    {
        SoundManager.Instance.PlayerLoss(Sounds.PlayerDeath, true);
        gameObject.SetActive(true);
    }
    void ReloadLevel()
    {
        //SceneManager.LoadScene(1);
        Scene scene = SceneManager.GetActiveScene();

        SceneManager.LoadScene(scene.buildIndex);

    }
}
