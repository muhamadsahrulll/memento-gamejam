using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public void LoadLevel(string nama)
    {
        SceneManager.LoadScene(nama);
    }

    public void exitGame()
    {
        Application.Quit();

        // Hanya untuk debugging di Editor Unity (hapus pada build final)
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }


}
