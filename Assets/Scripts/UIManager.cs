using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] public Sprite[] UIKalah;
    public bool isRestarted = false;

    public MusicManager MusicManager;
    public Button buttonRestart;

    public Image anak_GameOver;



    // Start is called before the first frame update
    void Start()
    {
        MusicManager = GameObject.Find("MusicManager").GetComponent<MusicManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void isRestart()
    {
        if (buttonRestart == true)
        {
            isRestarted = true;

            if (isRestarted)
            {
                MusicManager.vo_kalah_menang.Stop();
            }
        }
    }
}
