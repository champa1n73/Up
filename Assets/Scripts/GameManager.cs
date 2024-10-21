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

    [Header("Counters")]
    static int dieCount = 0;

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
        dieCount++;
        isGameOver = true;
        scoreManager.SaveHighestScore();
        UIControl.GetGameOverPanel().SetActive(true);
        Debug.Log(dieCount);
        if(dieCount % 2 == 0)
        {
            AdsManager.instance.GetRewardedAdObject().LoadRewardedAd();
            AdsManager.instance.GetRewardedAdObject().ShowRewardedAd();
        }
    }

    public void IncreaseSpeedRange()
    {
        minSpeed += minSpeedPerLevel;
        maxSpeed += maxSpeedPerLevel; 
    }

    
}
