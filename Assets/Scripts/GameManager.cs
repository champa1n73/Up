using UnityEngine;


public class GameManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] UIControl UIControl;
    [SerializeField] UIScoreDisplay UIScoreDisplay;
    [SerializeField] ScoreManager scoreManager;

    [Header("Speed Range")]
    [SerializeField] int minSpeed;
    [SerializeField] int maxSpeed;
    [SerializeField] int minSpeedPerLevel = 2;
    [SerializeField] int maxSpeedPerLevel = 2;

    [Header("Flags")]
    bool isGameOver;

    public int GetMinSpeed()
    {
        return minSpeed;
    }

    public int GetMaxSpeed()
    {
        return maxSpeed;
    }

    public void SetIsGameOver(bool isGameOver)
    {
        this.isGameOver = isGameOver;
    }

    public bool GetIsGameOver()
    {
        return isGameOver;
    }

    void Start() 
    {
        isGameOver = false;
    }

    public void GameOver()
    {
        isGameOver = true;
        scoreManager.SaveHighestScore();
        UIControl.GetGameOverPanel().SetActive(true);
    }

    public void IncreaseSpeedRange()
    {
        minSpeed += minSpeedPerLevel;
        maxSpeed += maxSpeedPerLevel; 
    }

    
}
