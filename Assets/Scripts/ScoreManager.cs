using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameManager gameManager;
    [SerializeField] UIScoreDisplay UIScoreDisplay;

    [Header("Score")]
    int score;
    int scorePerlevel;

    [Header("Flags")]
    bool isExecuted = false;

    public int GetScore()
    {
        return score;
    }

    void Start()
    {
        score = 0;
        scorePerlevel = 0;
    }

    public void AddScore(bool isPerfectHit)
    {
        if(isPerfectHit)
        {
            score += 2;
            scorePerlevel += 2;
        }
        else
        {
            score++;
            scorePerlevel++;
        }
        
        if(scorePerlevel >= 5)
        {
            gameManager.IncreaseSpeedRange();
            scorePerlevel = 0;
        }
    }

    public void SaveHighestScore()
    {
        if(isExecuted)
        {
            return;
        }
        if(score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
            UIScoreDisplay.GetHighestScoreText().text = "New High Score: " + PlayerPrefs.GetInt("HighScore");
        }
        else
        {
            UIScoreDisplay.GetHighestScoreText().text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString();
        }
        isExecuted = true;
        
    }
}
