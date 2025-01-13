using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseAndWin : MonoBehaviour
{
    public GameObject gameOver;
    public GameObject winGame;

    SceneController sceneController;
    MusicManager MusicManager;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //code untuk kalah
        // Periksa apakah game object yang menyentuh trap memiliki tag "Player"
        if (collision.CompareTag("Player"))
        {
            if (gameObject.CompareTag("gameOver"))
            {
                MusicManager.PlaySFX(MusicManager.death);
                // Nonaktifkan game object Player
                collision.gameObject.SetActive(false);

                gameOver.SetActive(true);
                MusicManager.kalah();
                MusicManager.vo_kalah_menang.Play();
                // Tampilkan pesan debug "kalah"
                //sceneController.NextLevel("level2");
                Debug.Log("Kalah");
            }

        }
        
        //code untuk menang
        // Periksa apakah game object yang menyentuh trap memiliki tag "Player"
        if (collision.CompareTag("Player"))
        {
            if (gameObject.CompareTag("winGame"))
            {
                MusicManager.PlaySFX(MusicManager.winGame);
                // Nonaktifkan game object Player
                collision.gameObject.SetActive(false);

                winGame.SetActive(true);

                // Tampilkan pesan debug "menang"
                //sceneController.NextLevel("level2");
                Debug.Log("Menang");
            }
        }
    }

    private void Awake()
    {
        MusicManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<MusicManager>();
    }
}
