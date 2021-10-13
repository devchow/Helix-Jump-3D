using System.Collections;
using GoogleMobileAds.Api;
using UnityEngine;

public class AdManager : MonoBehaviour
{
    private BannerView bannerAd;
    private InterstitialAd interstitial;

    public static AdManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        MobileAds.Initialize(InitializationStatus => { });
        this.RequestBanner();
    }

    private  AdRequest CreateAdRequest()
    {
        return new AdRequest.Builder().Build();
    }

    // Banner Ad
    private void RequestBanner()
    {
        string adUnitId = "ca-app-pub-3940256099942544/6300978111";
        //string appId = "ca-app-pub-3940256099942544~3347511713";
        this.bannerAd = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);
        this.bannerAd.LoadAd(this.CreateAdRequest());
    }

    // Interstitial Ad
    public void RequestInterstitial()
    {
        string adUnitId = "ca-app-pub-3940256099942544/1033173712";

        // Clean up interstitial ad before creating a new one
        if (this.interstitial != null)
            this.interstitial.Destroy();

        //string appId = "ca-app-pub-3940256099942544~3347511713";

        // create an Interstitial
        this.interstitial = new InterstitialAd(adUnitId);

        // Load an Interstitial ad
        this.interstitial.LoadAd(this.CreateAdRequest());
    }

    // Method to Show Interstitial Ad
    public void ShowInterstitial()
    {
        if(this.interstitial.IsLoaded())
        {
            interstitial.Show();
        }
        else
        {
            Debug.Log("Interstitial Ad is not ready yet.");
        }
    }

    void Update()
    {
        
    }
}
