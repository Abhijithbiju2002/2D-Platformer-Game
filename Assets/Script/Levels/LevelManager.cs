
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }
    public string Level1;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        if (GetLevelStatus(Level1) == LevelStatus.Locked)
        {
            SetLevelStatus(Level1, LevelStatus.Unlocked);
        }
    }
    public void MarkCurrentComplete()
    {
        Scene Currentscene = SceneManager.GetActiveScene();

        //set level status to complete
        Instance.SetLevelStatus(Currentscene.name, LevelStatus.Completed);

        //unlock next level
        int nextSceneIndex = Currentscene.buildIndex + 1;
        Scene nextscene = SceneManager.GetSceneAt(nextSceneIndex);
        Instance.SetLevelStatus(nextscene.name, LevelStatus.Unlocked);
    }
    public LevelStatus GetLevelStatus(string level)
    {
        LevelStatus levelstatus = (LevelStatus)PlayerPrefs.GetInt(level, 0);
        return levelstatus;
    }

    public void SetLevelStatus(string level, LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(level, (int)levelStatus);
    }


}
