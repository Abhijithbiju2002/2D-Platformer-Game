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
        gameObject.SetActive(true);
    }
    void ReloadLevel()
    {
        SceneManager.LoadScene(0);

    }
}
