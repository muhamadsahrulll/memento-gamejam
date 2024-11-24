using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractLemari : MonoBehaviour
{
    public GameObject piyama;
    public GameObject UITutor;
    private bool isPlayerInRange = false;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        // Mengecek apakah player menekan tombol E saat berada di area trigger
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            anim.SetBool("isOpen", true);
            // Mengubah status aktif GameObject A
            if (piyama != null)
            {
                piyama.SetActive(true);
                Debug.Log($"{piyama.name} diaktifkan!");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Mengecek apakah yang masuk adalah player
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = true;
            UITutor.SetActive(true);
            Debug.Log("Player berada di area trigger.");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Mengecek apakah player keluar dari area trigger
        if (collision.CompareTag("Player"))
        {
            UITutor.SetActive(false);
            isPlayerInRange = false;
            Debug.Log("Player keluar dari area trigger.");
        }
    }
}
