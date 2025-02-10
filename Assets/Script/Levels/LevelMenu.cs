using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    public Button[] buttons;

    private void Awake()
    {
        //It Checks How Many Levels Are Unlocked
        //This gets the number of unlocked levels from saved data.
        // If there’s no saved data, it starts with 1 unlocked level.
        int unlockedLevel = PlayerPrefs.GetInt("ReachedIndex", 1);
        unlockedLevel = Mathf.Clamp(unlockedLevel, 1, buttons.Length);

        //This makes all level buttons unclickable at first.
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
        //This enables only the unlocked levels so you can click them.
        for (int i = 0; i < unlockedLevel; i++)
        {
            buttons[i].interactable = true;
        }
    }

    //When you click a level button, it loads the level with that number.
    public void OpenLevel(int levelId)
    {
        string levelName = "Level " + levelId;
        SoundManager.Instance.Play(Sounds.ButtonClick);
        SceneManager.LoadScene(levelName);
    }

}
