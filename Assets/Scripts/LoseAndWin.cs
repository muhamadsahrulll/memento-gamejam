using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseAndWin : MonoBehaviour
{
    public GameObject gameOver;
    public GameObject winGame;

    SceneController sceneController;
    public MusicManager MusicManager;
    public UIManager UIManager;

    public void Start()
    {
        MusicManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<MusicManager>();
        //UIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if (UIManager != null)
        {
            Debug.Log("UIManager berhasil ditemukan dan diassign.");
        }
        else
        {
            Debug.LogError("UIManager tidak ditemukan! Pastikan UIManager ada pada objek Canvas.");
        }

        Debug.Log("UIManager reference: " + UIManager);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //code untuk kalah
        // Periksa apakah game object yang menyentuh trap memiliki tag "Player"
        if (collision.CompareTag("Player"))
        {
            if (gameObject.CompareTag("gameOver"))
            {
                if (gameObject.name == "EnemyHandphone")
                {
                    UIManager.anak_GameOver.sprite = UIManager.UIKalah[0];
                }

                if (gameObject.name == "EnemyHandphone2")
                {
                    UIManager.anak_GameOver.sprite = UIManager.UIKalah[1];
                }
                
                else if (gameObject.name == "EnemyTV")
                {
                    UIManager.anak_GameOver.sprite = UIManager.UIKalah[2];
                }

                else if (gameObject.name == "Robot")
                {
                    UIManager.anak_GameOver.sprite = UIManager.UIKalah[3];
                }

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
}
