using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button buttonPlay;

    private void Awake()
    {
        buttonPlay.onClick.AddListener(PlayGame);
    }
    void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
}
