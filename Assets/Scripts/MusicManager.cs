using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    [SerializeField] public AudioSource musicScource;
    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioSource footStepSource;
    [SerializeField] public AudioSource jumpSource;
    [SerializeField] public AudioSource vo_kalah_menang;

    public VideoPlayer videoPlayer;
    public bool isVideoMute = false;

    public static MusicManager instance;

    public AudioClip backsound;
    public AudioClip death;
    public AudioClip stepMovement;
    public AudioClip winGame;
    public AudioClip buttonClick;
    public AudioClip Jump;
    public AudioClip Landing;


    public AudioClip vo_kalah;
    public AudioClip vo_menang;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded; // Tambahkan listener untuk sceneLoaded
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        //buat play backsound tanpa diulang
        musicScource.clip = backsound;
        musicScource.Play();


    }
    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        AssignButtonListeners();
    }

    public void AssignButtonListeners()
    {
        //buat play sfx click button
        Button[] buttons = Resources.FindObjectsOfTypeAll<Button>();
        foreach (Button btn in buttons)
        {
            if (btn.CompareTag("PlayerControls"))
            {
                
            }

            else
            {
                btn.onClick.AddListener(() => PlaySFX(buttonClick));
            }
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
        Debug.Log("sfx button dipanggil");
    }
    public void PlayFootStep()
    {
        footStepSource.Play();
    }
    
    public void StopFootStep()
    {
        footStepSource.Stop();
    }
    
    public void JumpSFX()
    {
        jumpSource.Play();
    }

    public void kalah()
    {
        vo_kalah_menang.PlayOneShot(vo_kalah);
        if (isVideoMute == true)
        {
            vo_kalah_menang.mute = true;
        }

        else
        {
            vo_kalah_menang.mute = false;
        }
    }

    public void menang()
    {
        vo_kalah_menang.PlayOneShot(vo_menang);
        if (isVideoMute == true)
        {
            vo_kalah_menang.mute = true;
        }

        else
        {
            vo_kalah_menang.mute = false;
        }
    }

    public void VideoMute(bool value)
    {
        isVideoMute = value;
        if (isVideoMute == true)
        {
            Debug.Log("Video di Mute");
        }
        
        else
        {
            Debug.Log("Video di UnMute");
        }

    }
}
