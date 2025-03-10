using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdsManager : MonoBehaviour
{
    private LevelPlaySample levelPlaySample;

    public static AdsManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        BuatLoadAds();
    }

    // Start is called before the first frame update
    void Start()
    {
        levelPlaySample = GameObject.Find("Ads Manager").GetComponent<LevelPlaySample>();
        BuatLoadAds();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuatLoadAds()
    {
        levelPlaySample.LoadInterstitialAds();
    }

    public void BuatShowAds(bool isTrue)
    {
        if(isTrue == true)
        {
            
            levelPlaySample.ShowInterstitialAds();
            
        }
    }
}
