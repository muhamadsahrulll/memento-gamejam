using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    public VideoPlayer videoPlayer;  // VideoPlayer yang digunakan
    public VideoClip videoClip1;     // Video pertama
    public VideoClip videoClip2;     // Video kedua
    public string mainmenu;     // Nama scene yang akan dimuat


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
            videoPlayer.clip = videoClip2;
            videoPlayer.Play();  // Mulai video kedua
        }
        else if (videoPlayer.clip == videoClip2)
        {
            // Ketika video kedua selesai, ganti ke scene berikutnya
            SceneManager.LoadScene(mainmenu);
        }
    }
}
