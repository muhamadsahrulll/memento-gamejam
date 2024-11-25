using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
{
    [SerializeField] private GameObject[] dialogObjects; // Array untuk GameObject dialog
    [SerializeField] private string nextSceneName;       // Nama scene selanjutnya
    //SceneController sceneController;

    private int currentDialogIndex = 0;                 // Indeks dialog yang sedang ditampilkan

    void Start()
    {
        // Pastikan hanya dialog pertama yang aktif di awal
        for (int i = 0; i < dialogObjects.Length; i++)
        {
            dialogObjects[i].SetActive(i == 0);
        }
    }

    void Update()
    {
        // Jika tombol E ditekan
        if (Input.GetKeyDown(KeyCode.E))
        {
            ShowNextDialog();
        }
    }

    private void ShowNextDialog()
    {
        // Nonaktifkan dialog yang sedang aktif
        if (currentDialogIndex < dialogObjects.Length)
        {
            dialogObjects[currentDialogIndex].SetActive(false);
        }

        // Pindah ke dialog berikutnya
        currentDialogIndex++;

        // Jika masih ada dialog, aktifkan dialog berikutnya
        if (currentDialogIndex < dialogObjects.Length)
        {
            dialogObjects[currentDialogIndex].SetActive(true);
        }
        else
        {
            // Jika sudah tidak ada dialog, pindah ke scene berikutnya
            SceneManager.LoadScene(nextSceneName);
            //sceneController.NextLevel("level1");
        }
    }
}
