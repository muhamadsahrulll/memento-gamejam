using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
{
/*    [SerializeField] private GameObject[] dialogObjects; // Array untuk GameObject dialog
    [SerializeField] private AudioClip[] dialogAudioClips; // Array untuk AudioClip dialog*/
    [SerializeField] private string nextSceneName;       // Nama scene selanjutnya

    private int currentDialogIndex = 0;                 // Indeks dialog yang sedang ditampilkan

    public AudioSource dialogAudio;

    void Start()
    {
        /*// Pastikan hanya dialog pertama yang aktif di awal
        for (int i = 0; i < dialogObjects.Length; i++)
        {
            dialogObjects[i].SetActive(i == 0);
        }

        // Mainkan suara untuk dialog pertama jika ada
        if (dialogAudioClips.Length > 0 && dialogAudioClips[0] != null)
        {
            MusicManager.instance.PlaySFX(dialogAudioClips[0]);
        }*/
    }

    void Update()
    {
        if (!dialogAudio.isPlaying)
        {
            // Jika audio sudah selesai, muat scene selanjutnya
            SceneManager.LoadScene(nextSceneName);
        }
    }

    /*public void ShowNextDialog()
    {
        // Nonaktifkan dialog yang sedang aktif
        if (currentDialogIndex < dialogObjects.Length)
        {
            dialogObjects[currentDialogIndex].SetActive(false);
        }

        // Pindah ke dialog berikutnya
        currentDialogIndex++;

        // Jika masih ada dialog, aktifkan dialog berikutnya dan mainkan suara
        if (currentDialogIndex < dialogObjects.Length)
        {
            dialogObjects[currentDialogIndex].SetActive(true);

            // Mainkan suara untuk dialog yang baru aktif
            if (currentDialogIndex < dialogAudioClips.Length && dialogAudioClips[currentDialogIndex] != null)
            {
                MusicManager.instance.PlaySFX(dialogAudioClips[currentDialogIndex]);
            }
        }
        else
        {
            // Jika sudah tidak ada dialog, pindah ke scene berikutnya
            SceneManager.LoadScene(nextSceneName);
        }
    }*/
}
