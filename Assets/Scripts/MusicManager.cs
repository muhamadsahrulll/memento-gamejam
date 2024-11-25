using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] AudioSource musicScource;
    public static MusicManager instance;

    public AudioClip backsound;


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
}
