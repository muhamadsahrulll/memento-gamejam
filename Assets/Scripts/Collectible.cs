using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Periksa apakah game object yang menyentuh trap memiliki tag "Player"
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Mendapatkan Sikat Gigi");
            Destroy(gameObject);
        }
    }
}
