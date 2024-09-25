using TMPro;
using UnityEngine;

public class UIScoreDisplay : MonoBehaviour
{
    [Header("References")]
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI gameOverText;
    [SerializeField] TextMeshProUGUI highestScoreText;

    public TextMeshProUGUI GetHighestScoreText()
    {
        return highestScoreText;
    }

    void Start()
    {
        highestScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    void Update()
    {
        if(scoreManager != null)
        {
            scoreText.text = scoreManager.GetScore().ToString();
        }
        
        gameOverText.text = "You Scored:\n" + scoreText.text;
    }

}
