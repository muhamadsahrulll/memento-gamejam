using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public GameObject gameover;
    SceneController sceneController;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Periksa apakah game object yang menyentuh trap memiliki tag "Player"
        if (collision.CompareTag("Player"))
        {
            // Nonaktifkan game object Player
            collision.gameObject.SetActive(false);
            
            gameover.SetActive(true);
            // Tampilkan pesan debug "kalah"
            //sceneController.NextLevel("level2");
            Debug.Log("Kalah");
        }
    }
}
