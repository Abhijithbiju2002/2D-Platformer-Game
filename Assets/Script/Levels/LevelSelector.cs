
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
        LevelStatus levelstatus = LevelManager.Instance.GetLevelStatus(LevelName);
        switch (levelstatus)
        {
            case LevelStatus.Locked:
                Debug.Log("no can do");
                break;

            case LevelStatus.Unlocked:
                SceneManager.LoadScene(LevelName);
                break;

            case LevelStatus.Completed:
                SceneManager.LoadScene(LevelName);
                break;

        }

        SceneManager.LoadScene(LevelName);
    }
}
