using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    [SerializeField] Animator transitionAnim;

    //private void Awake()
    //{
        //if(instance == null)
        //{
            //instance = this;
            //DontDestroyOnLoad(gameObject);
        //}
        //else
        //{
            //Destroy(gameObject);
        //}
    //}

    public void NextLevel(string nama)
    {
        StartCoroutine(loadlevel(nama));
    }

    IEnumerator loadlevel(string nama)
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(nama);
        transitionAnim.SetTrigger("Start");
    }
    
}
