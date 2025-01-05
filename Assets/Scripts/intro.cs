using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class intro : MonoBehaviour
{
    public VideoPlayer videoPlayer;  // VideoPlayer yang digunakan
    public VideoClip videoClip1;     // Video pertama
    //public VideoClip videoClip2;     // Video kedua
    public string level1;     // Nama scene yang akan dimuat


    // Start is called before the first frame update
    void Start()
    {
        // Menetapkan VideoPlayer dan video pertama
        videoPlayer.clip = videoClip1;

        // Menambahkan listener untuk event loopPointReached
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // Ketika video pertama selesai, ganti dengan video kedua
        if (videoPlayer.clip == videoClip1)
        {
            SceneManager.LoadScene(level1);
            //videoPlayer.clip = videoClip2;
            //videoPlayer.Play();  // Mulai video kedua
        }
        
    }
}
