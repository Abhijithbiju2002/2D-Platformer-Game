using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button buttonPlay;
    public GameObject levelSelection;

    private void Awake()
    {
        buttonPlay.onClick.AddListener(PlayGame);
    }
    void PlayGame()
    {
        //SceneManager.LoadScene(1);
        SoundManager.Instance.Play(Sounds.ButtonClick);
        levelSelection.SetActive(true);
    }
}
