using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] AudioSource musicScource;
    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioSource footStepSource;

    public static MusicManager instance;

    public AudioClip backsound;
    public AudioClip death;
    public AudioClip stepMovement;



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
}
