
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelSelector : MonoBehaviour
{
    private Button button;
    public string LevelName;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(onClick);
    }

    private void onClick()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        SoundManager.Instance.PlayLevelMusic(LevelName);
        SceneManager.LoadScene(LevelName);
    }
}
