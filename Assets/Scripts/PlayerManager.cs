using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using Unity;

public class PlayerManager : MonoBehaviour
{



    private float height=0.3f;
    public float growAmount, autogrowAmount;
    public Text heightText,pointText,CurrentPowerText,AutoCurrentPowerText;
    private float heightcount = 180.0f;
    private float heightcountUpgrade = 1.0f, autoheightcountUpgrade = 0.1f;

    public float points;
    public float pointsupgrade=2,autopointsupgrade=2;
    public int limit = 50, autolimit = 1000;
    Animator anim;
    AudioSource audio;
    private AudioSource musicSource;

    public bool autoUpgradeEnabled = false;

    private RewardedAd rewardedAd;

   

    private void Start()
    {

         if (!autoUpgradeEnabled)
         {
             AutoCurrentPowerText.text = "Upgrade Auto Power +1 \n" + "Current Auto Power: 0" + "\n" + "To Unlock: " + autolimit;
         }


        RequestRewardedAd();
       

        height = PlayerPrefs.GetFloat("height11", height);
        growAmount = PlayerPrefs.GetFloat("growAmount1", growAmount);
        autogrowAmount = PlayerPrefs.GetFloat("autogrowAmount1", autogrowAmount);
        heightcount = PlayerPrefs.GetFloat("heightcount11", heightcount);
        heightcountUpgrade = PlayerPrefs.GetFloat("heightcountUpgrade11", heightcountUpgrade);
        autoheightcountUpgrade = PlayerPrefs.GetFloat("autoheightcountUpgrade1", autoheightcountUpgrade);
        points = PlayerPrefs.GetFloat("points1", points);
        pointsupgrade = PlayerPrefs.GetFloat("pointsupgrade1", pointsupgrade);
        autopointsupgrade = PlayerPrefs.GetFloat("autopointsupgrade1", autopointsupgrade);
        limit = PlayerPrefs.GetInt("limit1", limit);
        autolimit = PlayerPrefs.GetInt("autolimit1", autolimit);
        autoUpgradeEnabled = PlayerPrefs.GetInt("autoUpgradeEnabled1", 0) == 1;


        if (Input.GetMouseButtonDown(0))
        {
            pointText.text = "Points: " + points + 2;

        }

      

        audio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        heightText.text = "Height: " + (heightcount / 100.0f).ToString("F2") + "m";
        CurrentPowerText.text = "Upgrade Click Power +1 \n" + "Current Click Power: " + pointsupgrade + "\n" + "To Unlock: " + limit;
        AutoCurrentPowerText.text = "Upgrade Auto Power +1 \n" + "Current Auto Power: " + autopointsupgrade + "\n" + "To Unlock: " + autolimit;


        musicSource = GameObject.FindGameObjectWithTag("music").GetComponent<AudioSource>();


    }

    void Update()
    {


        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {

            audio.Play();
            bool value = !anim.GetBool("Lifted");
            anim.SetBool("Lifted", value);
            height += growAmount;
            heightcount += heightcountUpgrade;
            points += pointsupgrade;
            transform.localScale = new Vector3(height, height, height);
            heightText.text = "Height: " + (heightcount / 100.0f).ToString("F2") + "m";
            pointText.text = "Points: " + points;
            CurrentPowerText.text = "Upgrade Click Power +1 \n" + "Current Click Power: " + pointsupgrade + "\n" + "To Unlock: " + limit;
            AutoCurrentPowerText.text = "Upgrade Auto Power +1 \n" + "Current Auto Power: " + autopointsupgrade + "\n" + "To Unlock: " + autolimit;
        }


        if (autoUpgradeEnabled)
        {
           
            height += autogrowAmount;
            heightcount += autoheightcountUpgrade;
            points += autopointsupgrade;
            transform.localScale = new Vector3(height, height, height);
            
            bool value = !anim.GetBool("Lifted");
            anim.SetBool("Lifted", value);
            heightText.text = "Height: " + (heightcount / 100.0f).ToString("F2") + "m";
            pointText.text = "Points: " + points;
            CurrentPowerText.text = "Upgrade Click Power +1 \n" + "Current Click Power: " + pointsupgrade + "\n" + "To Unlock: " + limit;
            AutoCurrentPowerText.text = "Upgrade Auto Power +1 \n" + "Current Auto Power: " + autopointsupgrade + "\n" + "To Unlock: " + autolimit;
             Debug.Log("Otomatik Yükseltildi");
        }




       

        PlayerPrefs.SetFloat("height11", height);
          PlayerPrefs.SetFloat("growAmount1", growAmount);
          PlayerPrefs.SetFloat("autogrowAmount1", autogrowAmount);
     
          PlayerPrefs.SetFloat("heightcount11", heightcount);
          PlayerPrefs.SetFloat("heightcountUpgrade11", heightcountUpgrade);
          PlayerPrefs.SetFloat("autoheightcountUpgrade1", autoheightcountUpgrade);
          PlayerPrefs.SetFloat("points1", points);
          PlayerPrefs.SetFloat("pointsupgrade1", pointsupgrade);
          PlayerPrefs.SetFloat("autopointsupgrade1", autopointsupgrade);
          PlayerPrefs.SetInt("limit1", limit);
          PlayerPrefs.SetInt("autolimit1", autolimit);
          PlayerPrefs.SetInt("autoUpgradeEnabled1", autoUpgradeEnabled ? 1 : 0); 



    }

    public void UpgradePower()
    {
        heightText.text = "Height: " + (heightcount / 100.0f).ToString("F2") + "m";
        pointText.text = "Points: " + points;
        CurrentPowerText.text = "Upgrade Click Power +1 \n" + "Current Click Power: " + pointsupgrade + "\n" + "To Unlock: " + limit;
        AutoCurrentPowerText.text = "Upgrade Auto Power +1 \n" + "Current Auto Power: " + autopointsupgrade + "\n" + "To Unlock: " + autolimit;
        if (points>=limit)
        {

            height = 0.3f;
            heightcount = 180.0f;
            transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            transform.position = new Vector3(transform.position.x, 70.5f, transform.position.z);
            points -= limit;
            pointsupgrade = pointsupgrade * 2;
            growAmount = growAmount * 2;
            heightcountUpgrade = heightcountUpgrade * 2;
            limit = limit * 4;

            heightText.text = "Height: " + (heightcount / 100.0f).ToString("F2") + "m";
            pointText.text = "Points: " + points;
            CurrentPowerText.text = "Upgrade Click Power +1 \n" + "Current Click Power: " + pointsupgrade + "\n" + "To Unlock: " + limit;
            AutoCurrentPowerText.text = "Upgrade Auto Power +1 \n" + "Current Auto Power: " + autopointsupgrade + "\n" + "To Unlock: " + autolimit;

            Debug.Log("Yükseltildi");
        }
        else
        {

            Debug.Log("Yetersiz Puan");
        }
    }



    public void AutoUpgrade()
    {
        if (points >= autolimit)
        {
            autoUpgradeEnabled = true;
            points -= autolimit;
            autolimit = autolimit * 2;
            autopointsupgrade = autopointsupgrade * 2;
            autogrowAmount = autogrowAmount * 2;
            autoheightcountUpgrade = autoheightcountUpgrade * 2;

        }

           
    }

    public void RequestRewardedAd()
    {
        string adUnitId = "ca-app-pub-8896981555924026/3790225091";

        this.rewardedAd = new RewardedAd(adUnitId);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);

        // Set up ad event handlers

        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
    }



    void HandleUserEarnedReward(object sender, Reward args)
    {
        pointsupgrade = pointsupgrade * 2;
        growAmount = growAmount * 2;
        heightcountUpgrade = heightcountUpgrade * 2;
        limit = limit * 2;
    }


    public void ShowRewardedAd()
    {
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
            RequestRewardedAd();
        }
  
    }

  

    public void ToggleMusic()
    {
        // Check if the music source is currently playing
        if (musicSource.isPlaying)
        {
            // If so, stop it
            musicSource.Stop();
            audio.Stop();
        }
        else
        {
            // Otherwise, start playing it again
            musicSource.Play();
            audio.Play();
        }
    }

}



