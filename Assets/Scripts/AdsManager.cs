using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsManager : MonoBehaviour
{
    public static AdsManager instance;
    [SerializeField] BannerAd bannerAd;
    [SerializeField] RewardedAdObject rewardedAdObject;

    public BannerAd GetBannerAd()
    {
        return bannerAd;
    }

    public RewardedAdObject GetRewardedAdObject()
    {
        return rewardedAdObject;
    }

    private void Awake()
    {
        ManageSingleton();
    }

    private void Start()
    {
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {
            // This callback is called once the MobileAds SDK is initialized.
        });
    }

    void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
