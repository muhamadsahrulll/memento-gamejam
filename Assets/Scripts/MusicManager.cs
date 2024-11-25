using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] AudioSource musicScource;

    public AudioClip backsound;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        //buat play backsound tanpa diulang
        musicScource.clip = backsound;
        musicScource.Play();
        
    }
}
