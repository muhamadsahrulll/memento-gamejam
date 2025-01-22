using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] public Sprite[] UIKalah;
    [SerializeField] public Sprite[] popUpSprites;
    public bool isRestarted = false;

    public MusicManager MusicManager;
    public Button buttonRestart;

    public Image anak_GameOver;
    public Image popUpImage;

    public Animation pop_up;

    public Color colorMute;
    public Color colorUnmute;

    public Button musik;
    public SuaraManager SuaraManager;
    // Start is called before the first frame update
    void Start()
    {
        musik.onClick.AddListener(SuaraManager.musik_OnOff);
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

    public void popUpNotif()
    {
        pop_up.PlayQueued("pop_up");
       
    }

    public void ChangeButtonColor()
    {
        if(MusicManager.storeIsMusicMute == true)
        {
            // Ambil ColorBlock dari Button
            ColorBlock colorBlock = musik.colors;

            // Ubah warna NormalColor
            colorBlock.selectedColor = colorMute;

            // Terapkan kembali ColorBlock ke Button
            musik.colors = colorBlock;
        } else
        {
            // Ambil ColorBlock dari Button
            ColorBlock colorBlock = musik.colors;

            // Ubah warna NormalColor
            colorBlock.selectedColor = colorUnmute;

            // Terapkan kembali ColorBlock ke Button
            musik.colors = colorBlock;
        }
    }
}
