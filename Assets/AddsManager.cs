using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AddsManager : MonoBehaviour, IUnityAdsListener
{
    public static AddsManager Instance
    {
        private set;
        get;
    }
#if UNITY_IOS
    private const string gameId = "4219390";
    private const string videoAdId = "Interstitial_iOS";
    private const string rewardAdId = "Rewarded_iOS";
    private const string bannerAdId = "Banner_iOS";
#else
    private const string gameId = "4219391";
    private const string videoAdId = "Interstitial_Android";
    private const string rewardAdId = "Rewarded_Android";
    private const string bannerAdId = "Banner_Android";
#endif

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == this)
        {
            Advertisement.AddListener(this);
            Advertisement.Initialize(gameId);
            ShowBanner();
        }
    }

    public void PlayAd()
    {
        if (Advertisement.IsReady(videoAdId))
        {
            Advertisement.Show(videoAdId);
        }
    }

    public void PlayRewardedAd()
    {
        if (Advertisement.IsReady(rewardAdId))
        {
            Advertisement.Show(rewardAdId);
        }
        else
        {
            Debug.Log("Rewarded ad is not ready!");
        }
    }

    public void ShowBanner()
    {
        if (Advertisement.IsReady(bannerAdId))
        {
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
            Advertisement.Banner.Show(bannerAdId);
        }
        else
        {
            StartCoroutine(RepeatShowBanner());
        }
    }

    public void HideBanner()
    {
        Advertisement.Banner.Hide();
    }

    IEnumerator RepeatShowBanner()
    {
        yield return new WaitForSeconds(1);
        ShowBanner();
    }

    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log("ADS ARE READY!");
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log("ERROR: " + message);
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("VIDEO STARTED");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (placementId == rewardAdId && showResult == ShowResult.Finished)
        {
            Debug.Log("PLAYER SHOULD BE REWARDED!");
        }
    }
}
