using TMPro;
using UnityEngine;

public class ScoreCo : MonoBehaviour
{
    private int score = 0;
    private TextMeshProUGUI ScoreText;

    private void Awake()
    {
        ScoreText = GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        RefreshUi();
    }

    public void IncreaseScore(int increment)
    {
        score += increment;
        RefreshUi();
    }
    private void RefreshUi()
    {
        ScoreText.text = "Score: " + score;
    }
}
