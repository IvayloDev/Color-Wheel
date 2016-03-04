using UnityEngine;
using System.Collections;
using GoogleMobileAds; 

public class Ads : MonoBehaviour {
	
	private AdMobPlugin admob;
	private const string Interstitial_ID = "ID";
	private const string Banner_ID = "ID";
	public static int adCount = 0;
	
	void Awake () {
		admob = GetComponent<AdMobPlugin>();
		admob.CreateBanner(Banner_ID,AdMobPlugin.AdSize.SMART_BANNER,true, Interstitial_ID);
		admob.RequestAd();
		if(adCount == 3){
			admob.RequestInterstitial();
		}
	}
	void Update () {
		HandleInterstitialLoaded();
		
	}
	void OnEnable(){
		AdMobPlugin.InterstitialLoaded += HandleInterstitialLoaded;
	}
	
	void OnDisable() {
		
		AdMobPlugin.InterstitialLoaded -= HandleInterstitialLoaded;
		
	}
	
	public void HandleInterstitialLoaded() {
		
		if(Collision.EndIsOn && adCount == 4){
			admob.ShowInterstitial();
			adCount = 0;
		}
	}

}

