using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] AudioSource musicScource;
    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioSource footStepSource;
    [SerializeField] public AudioSource vo_kalah_menang;

    public static MusicManager instance;

    public AudioClip backsound;
    public AudioClip death;
    public AudioClip stepMovement;
    public AudioClip winGame;

    public AudioClip vo_kalah;
    public AudioClip vo_menang;

    public SceneLoad SceneLoad;

    public UIManager UIManager;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
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

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
    public void PlayFootStep()
    {
        footStepSource.Play();
    }

    public void kalah()
    {
        vo_kalah_menang.PlayOneShot(vo_kalah);
    }
    
    public void menang()
    {
        vo_kalah_menang.PlayOneShot(vo_menang);
    }
}
